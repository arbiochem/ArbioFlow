using ArbioFlow.Data;
using ArbioFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace ArbioFlow.Repository
{
    public class PreparationRepo
    {
        private readonly AppDbContext context;
        private readonly ArbioDbContext contextDb;
        public PreparationRepo(AppDbContext _context, ArbioDbContext _contextDb)
        {
            this.context = _context;
            this.contextDb = _contextDb;
        }
        public async Task<IReadOnlyList<LigneFactureDto>> GetLignesAsync(String doPiece)
        {
            return await (
                from d in context.FDoclignes.AsNoTracking()
                where d.DoPiece == doPiece
                join a in context.FArticles.AsNoTracking()
                    on d.ArRef equals a.ArRef into articles
                from a in articles.DefaultIfEmpty()      // left join : garde les lignes sans article
                select new LigneFactureDto
                {
                    ArRef = d.ArRef,
                    DlDesign = d.DlDesign,
                    DlQte = Convert.ToDecimal(d.DlQte),
                    FaCodeFamille = a.FaCodeFamille
                })
                .ToListAsync();
        }
        public async Task<IReadOnlyList<PreparationDto>> getPreparation(
    DateTime? dateDebut, DateTime? dateFin, string? q = null, int? depot = null)
        {
            if (!dateDebut.HasValue)
                return Array.Empty<PreparationDto>();

            var docs = context.FDocentetes
                .AsNoTracking()
                .Where(d => (d.DoType == 7 || d.DoType == 23) && d.DeNo == depot);

            var debut = dateDebut.Value.Date;
            docs = docs.Where(d => d.DoDate >= debut);

            if (dateFin.HasValue)
            {
                var finExclue = dateFin.Value.Date.AddDays(1);
                docs = docs.Where(d => d.DoDate < finExclue);
            }

            if (!string.IsNullOrWhiteSpace(q))
                docs = docs.Where(d => d.DoPiece.Contains(q) || d.DoTiers.Contains(q));

            // 1. Factures + client (contexte Sage)
            var liste = await docs
                .Join(context.FComptets,
                      d => d.DoTiers,
                      t => t.CtNum,
                      (d, t) => new PreparationDto
                      {
                          DoPiece = d.DoPiece,
                          DoDate = d.DoDate,
                          DoTiers = d.DoTiers,
                          CtIntitule = t.CtIntitule
                      })
                .OrderByDescending(p => p.DoDate)
                .ThenByDescending(p => p.DoPiece)
                .ToListAsync();

            if (liste.Count == 0)
                return liste;

            var pieces = liste
                .Where(p => !string.IsNullOrEmpty(p.DoPiece))
                .Select(p => p.DoPiece!)
                .Distinct()
                .ToList();

            // 2. Nombre total de lignes par facture (contexte Sage)
            var totaux = new Dictionary<string, int>();
            foreach (var lot in pieces.Chunk(1000))
            {
                var part = await context.FDoclignes
                    .AsNoTracking()
                    .Where(l => lot.Contains(l.DoPiece))
                    .GroupBy(l => l.DoPiece)
                    .Select(g => new { DoPiece = g.Key, Nb = g.Count() })
                    .ToListAsync();

                foreach (var x in part)
                    totaux[x.DoPiece] = x.Nb;
            }

            // 3. Lignes validées par facture (contexte ArbioFlow)
            var validees = new Dictionary<string, int>();
            foreach (var lot in pieces.Chunk(1000))
            {
                var part = await contextDb.HistoriqueValidations
                    .AsNoTracking()
                    .Where(h => lot.Contains(h.DoPiece) && h.Depot == depot)
                    .GroupBy(h => h.DoPiece)
                    .Select(g => new
                    {
                        DoPiece = g.Key,
                        Nb = g.Select(x => x.ArRef).Distinct().Count()
                    })
                    .ToListAsync();

                foreach (var x in part)
                    validees[x.DoPiece] = x.Nb;
            }

            // 4. Fusion en mémoire
            foreach (var p in liste)
            {
                if (p.DoPiece == null) continue;

                p.NbLignesTotal = totaux.GetValueOrDefault(p.DoPiece);
                p.NbLignesValidees = validees.GetValueOrDefault(p.DoPiece);
            }

            return liste;
        }
    }
}

using ArbioFlow.Data;
using ArbioFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace ArbioFlow.Repository
{
    public class PreparationRepo
    {
        private readonly AppDbContext context;
        public PreparationRepo(AppDbContext _context)
        {
            this.context = _context;
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
        DateTime? dateDebut, DateTime? dateFin, string? q = null, int? depot=null)
        {
            if (dateDebut.HasValue)
            {
                var docs = context.FDocentetes
                .AsNoTracking()
                .Where(d => (d.DoType == 7 || d.DoType == 23) && d.DeNo == depot);

                if (dateDebut.HasValue)
                {
                    var debut = dateDebut.Value.Date;
                    docs = docs.Where(d => d.DoDate >= debut);
                }

                if (dateFin.HasValue)
                {
                    var finExclue = dateFin.Value.Date.AddDays(1);
                    docs = docs.Where(d => d.DoDate < finExclue);
                }

                if (!string.IsNullOrWhiteSpace(q))
                    docs = docs.Where(d => d.DoPiece.Contains(q) || d.DoTiers.Contains(q));

                return await docs
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
            }
            else
            {
                return Array.Empty<PreparationDto>();
            }
        }
    }
}

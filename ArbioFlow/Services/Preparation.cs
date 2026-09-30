using Microsoft.EntityFrameworkCore;
using ArbioFlow.Models;
using ArbioFlow.Data;

namespace ArbioFlow.Services
{
    public class Preparation:IPreparation
    {
        private readonly AppDbContext context;
        public Preparation(AppDbContext _context)
        {
            this.context= _context;
        }

        public async Task<IReadOnlyList<PreparationDto>> getPreparation(
        DateTime? dateDebut, DateTime? dateFin, string? q = null)
        {
            if (dateDebut.HasValue)
            {
                var docs = context.FDocentetes.AsNoTracking()
                    .Where(d => d.DoType == 7 || d.DoType==23);

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

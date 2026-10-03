using ArbioFlow.Data;
using ArbioFlow.Models;
using System.ComponentModel.DataAnnotations;

namespace ArbioFlow.Repository
{
    public class ValiderLigneRepo
    {
        private readonly ArbioDbContext _context;
        public ValiderLigneRepo(ArbioDbContext context)
        {
            this._context = context;
        }

        public async Task<ValidationResultat> ValiderLigneAsync(string doPiece, string arRef, decimal qtePreparee, string designation, string validateur, int depot)
        {
            var maintenant = DateTime.Now;

            _context.HistoriqueValidations.Add(new HistoriqueValidationDto
            {
                DoPiece = doPiece,
                ArRef = arRef,
                QteValidee = qtePreparee,
                Designation=designation,
                Validateur = validateur,
                DateValidation = maintenant,
                Depot = depot
            });

            var n = await _context.SaveChangesAsync();

            return n > 0
                ? new ValidationResultat(true, "Ligne validée.", maintenant)
                : new ValidationResultat(false, "Aucune ligne enregistrée.");
        }
    }
}

using ArbioFlow.Models;
using ArbioFlow.Repository;

namespace ArbioFlow.Services
{
    public class ValiderLigne : IValiderLigne
    {
        private readonly ValiderLigneRepo _validerLigne;

        public ValiderLigne(ValiderLigneRepo validerLigne)
        {
            _validerLigne = validerLigne;
        }

        public async Task<ValidationResultat> ValiderLigneAsync(string DoPiece,
                string ArRef,
                decimal QtePreparee,
                string designation,
                string name,
                int DepotCourant)
        {
            return await _validerLigne.ValiderLigneAsync(DoPiece,
                ArRef,
                QtePreparee,
                designation,
                name,
                DepotCourant);
        }
    }
}

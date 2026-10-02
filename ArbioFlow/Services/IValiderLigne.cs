using ArbioFlow.Models;

namespace ArbioFlow.Services
{
    public interface IValiderLigne
    {
        Task<ValidationResultat> ValiderLigneAsync(string DoPiece,
                string ArRef,
                decimal QtePreparee,
                string designation,
                string name,
                int DepotCourant);
    }
}

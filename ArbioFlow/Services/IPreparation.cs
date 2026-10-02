using ArbioFlow.Models;

namespace ArbioFlow.Services
{
    public interface IPreparation
    {
        Task<IReadOnlyList<PreparationDto>> getPreparation(DateTime? dateDebut, DateTime? dateFin, String? q,int depot);
        Task<IReadOnlyList<LigneFactureDto>> GetLignesAsync(string doPiece);
    }
}

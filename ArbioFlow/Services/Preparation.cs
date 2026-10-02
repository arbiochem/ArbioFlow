using Microsoft.EntityFrameworkCore;
using ArbioFlow.Models;
using ArbioFlow.Data;
using System.Reflection.Metadata.Ecma335;
using ArbioFlow.Repository;

namespace ArbioFlow.Services
{
    public class Preparation:IPreparation
    {
        private readonly PreparationRepo _preparation;
        public Preparation(PreparationRepo preparation)
        {
            this._preparation = preparation;
        }

        public Task<IReadOnlyList<LigneFactureDto>> GetLignesAsync(string doPiece)
        {
           return _preparation.GetLignesAsync(doPiece);
        }

        public Task<IReadOnlyList<PreparationDto>> getPreparation(DateTime? dateDebut, DateTime? dateFin, string? q,int depot)
        {
            return _preparation.getPreparation(dateDebut, dateFin, q,depot);
        }
    }
}

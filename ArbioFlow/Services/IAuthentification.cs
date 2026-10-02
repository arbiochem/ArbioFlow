using ArbioFlow.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace ArbioFlow.Services
{
    public record UtilisateurInfo(string Login, bool Actif, bool ResetEnAttente, DateTime? DateDemande);

    public interface IAuthentification
    {
        Task<List<SelectListItem>> ChargerDepots();
        Task<bool> ValiderAsync(string utilisateur, string password);
        Task CreerOuMajAsync(string utilisateur, string password);
        Task<List<UtilisateurInfo>> ListerAsync();
        Task SupprimerAsync(string utilisateur);

        Task<string?> DemanderInscriptionAsync(string utilisateur, string password);
        Task DemanderResetAsync(string utilisateur, string password);
        Task ApprouverAsync(string utilisateur);
        Task RefuserAsync(string utilisateur);

        Task<FDepot> recupDepot(int code);

    }
}
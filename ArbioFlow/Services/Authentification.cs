using ArbioFlow.Models;
using ArbioFlow.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArbioFlow.Services
{
    public class Authentification : IAuthentification
    {
        private readonly AuthentificationRepo _auth;  
        public Authentification(AuthentificationRepo auth)
        {
            this._auth = auth;
        }

        public Task ApprouverAsync(string utilisateur)
        {
            return _auth.ApprouverAsync(utilisateur);
        }

        public Task<List<SelectListItem>> ChargerDepots()
        {
            return _auth.ChargerDepots();
        }

        public Task CreerOuMajAsync(string utilisateur, string password)
        {
            return _auth.CreerOuMajAsync(utilisateur, password);
        }

        public Task<string?> DemanderInscriptionAsync(string utilisateur, string password)
        {
            return _auth.DemanderInscriptionAsync(utilisateur,password);
        }

        public Task DemanderResetAsync(string utilisateur, string password)
        {
            return _auth.DemanderResetAsync(utilisateur,password);
        }

        public Task<List<UtilisateurInfo>> ListerAsync()
        {
            return _auth.ListerAsync();
        }

        public Task<FDepot> recupDepot(int code)
        {
            return _auth.recupDepot(code);
        }

        public Task RefuserAsync(string utilisateur)
        {
            return _auth.RefuserAsync(utilisateur);
        }

        public Task SupprimerAsync(string utilisateur)
        {
            return _auth.SupprimerAsync(utilisateur);
        }

        public Task<bool> ValiderAsync(string utilisateur, string password)
        {
            return _auth.ValiderAsync(utilisateur,password);
        }
    }
}
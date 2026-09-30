namespace ArbioFlow.Services
{
    public record UtilisateurInfo(string Login, bool Actif, bool ResetEnAttente, DateTime? DateDemande);

    public interface IAuthentification
    {
        Task<bool> ValiderAsync(string utilisateur, string password);
        Task CreerOuMajAsync(string utilisateur, string password);
        Task<List<UtilisateurInfo>> ListerAsync();
        Task SupprimerAsync(string utilisateur);

        Task<string?> DemanderInscriptionAsync(string utilisateur, string password);
        Task DemanderResetAsync(string utilisateur, string password);
        Task ApprouverAsync(string utilisateur);
        Task RefuserAsync(string utilisateur);
    }
}
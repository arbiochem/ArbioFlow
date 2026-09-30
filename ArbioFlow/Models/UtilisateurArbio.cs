namespace ArbioFlow.Models;

public class UtilisateurArbio
{
    public int Id { get; set; }
    public string Login { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public bool Actif { get; set; }
    public string? PendingHash { get; set; }
    public DateTime? DateDemande { get; set; }
}
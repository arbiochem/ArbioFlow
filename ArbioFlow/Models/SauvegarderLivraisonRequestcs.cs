namespace ArbioFlow.Models
{
    public class SauvegarderLivraisonRequest
    {
        public string DoPiece { get; set; } = "";
        public string Champ { get; set; } = "";
        public string? Valeur { get; set; }
    }
}
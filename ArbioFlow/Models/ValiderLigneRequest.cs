namespace ArbioFlow.Models
{
    public class ValiderLigneRequest
    {
        public string DoPiece { get; set; } = "";
        public string ArRef { get; set; } = "";
        public decimal QtePreparee { get; set; }

        public string Designation { get; set; } = "";
        public LivraisonDto? Livraison { get; set; }   // nouveau
    }
}

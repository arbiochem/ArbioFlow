namespace ArbioFlow.Models
{
    public class LivraisonDto
    {
        public string? TypeFacture { get; set; }
        public string? TypeRetrait { get; set; }
        public string? Vehicule { get; set; }
        public string? Chauffeur { get; set; }
        public DateTime? DateLivraison { get; set; }
        public DateTime? DateDebutPrep { get; set; }
        public string? HeureDebutPrep { get; set; }
        public string? StatutPrep { get; set; }
        public string? CauseNonTransfert { get; set; }
        public string? Observations { get; set; }
    }
}

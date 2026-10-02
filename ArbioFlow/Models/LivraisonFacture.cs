namespace ArbioFlow.Models
{
    public class LivraisonFacture
    {
        public int Id { get; set; }
        public string DoPiece { get; set; } = "";

        public string? TypeFacture { get; set; }
        public string? TypeRetrait { get; set; }
        public string? Vehicule { get; set; }
        public string? Chauffeur { get; set; }

        public DateTime? DateLivraison { get; set; }
        public DateTime? DateDebutPrep { get; set; }
        public TimeSpan? HeureDebutPrep { get; set; }   // converti depuis "HH:mm"

        public string? StatutPrep { get; set; }
        public string? CauseNonTransfert { get; set; }
        public string? Observations { get; set; }

        public string? ModifiePar { get; set; }
        public DateTime DateMaj { get; set; } = DateTime.Now;
    }
}

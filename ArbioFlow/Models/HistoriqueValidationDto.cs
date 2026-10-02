namespace ArbioFlow.Models
{
    public class HistoriqueValidationDto
    {
        public int Id { get; set; }
        public string DoPiece { get; set; } = "";
        public string ArRef { get; set; } = "";
        public DateTime DateValidation { get; set; }
        public string Validateur { get; set; } = "";
        public string Designation { get; set; } = "";
        public decimal QteValidee { get; set; }
    }
}

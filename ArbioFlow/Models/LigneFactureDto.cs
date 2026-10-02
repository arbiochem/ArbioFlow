namespace ArbioFlow.Models;

public class LigneFactureDto
{
    public string ArRef { get; set; } = "";
    public string DlDesign { get; set; } = "";
    public decimal DlQte { get; set; }

    public string FaCodeFamille { get; set; } = "";
}
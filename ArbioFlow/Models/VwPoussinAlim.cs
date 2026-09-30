using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwPoussinAlim
{
    public string? CtNum { get; set; }

    public string? CtIntitule { get; set; }

    public DateTime? DoDate { get; set; }

    public string DoPiece { get; set; } = null!;

    public string FaCodeFamille { get; set; } = null!;

    public string? ArRef { get; set; }

    public string? DlDesign { get; set; }

    public decimal? DlQte { get; set; }

    public decimal? DlMontantHt { get; set; }
}

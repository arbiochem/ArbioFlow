using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwMveMv
{
    public string? DeIntitule { get; set; }

    public string? DoPiece { get; set; }

    public DateTime? DoDate { get; set; }

    public string? CtNum { get; set; }

    public string? CtIntitule { get; set; }

    public string? DoRef { get; set; }

    public string? ArRef { get; set; }

    public string? DlDesign { get; set; }

    public decimal? DlQte { get; set; }

    public decimal? DlMontantHt { get; set; }

    public string DocType { get; set; } = null!;
}

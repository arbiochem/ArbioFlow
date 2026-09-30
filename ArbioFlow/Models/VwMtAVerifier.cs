using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwMtAVerifier
{
    public DateTime? DoDate { get; set; }

    public string DoPiece { get; set; } = null!;

    public string? DoRef { get; set; }

    public string Source { get; set; } = null!;

    public string Dest { get; set; } = null!;

    public string? ArRef { get; set; }

    public string? DlDesign { get; set; }

    public decimal? DlQte { get; set; }
}

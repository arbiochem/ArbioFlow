using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwSanslot
{
    public string Mvtstock { get; set; } = null!;

    public string? DoPiece { get; set; }

    public DateTime? DoDate { get; set; }

    public string? DoRef { get; set; }

    public string? ArRef { get; set; }

    public decimal? DlQte { get; set; }

    public int? DeNo { get; set; }

    public int? DlNo { get; set; }

    public string? LsNoSerie { get; set; }

    public string Action { get; set; } = null!;
}

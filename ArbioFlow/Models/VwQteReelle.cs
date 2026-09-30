using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwQteReelle
{
    public string ArRef { get; set; } = null!;

    public string? LsNoSerie { get; set; }

    public int? DlNoIn { get; set; }

    public decimal? StockReel { get; set; }
}

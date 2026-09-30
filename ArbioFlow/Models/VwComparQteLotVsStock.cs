using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwComparQteLotVsStock
{
    public string ArRef { get; set; } = null!;

    public string? ArDesign { get; set; }

    public int? DeNo { get; set; }

    public string DeIntitule { get; set; } = null!;

    public decimal? AsQteSto { get; set; }

    public decimal? LsQteRestant { get; set; }

    public decimal? Ecart { get; set; }
}

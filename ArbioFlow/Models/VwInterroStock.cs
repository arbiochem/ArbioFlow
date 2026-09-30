using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwInterroStock
{
    public string? DeIntitule { get; set; }

    public string? FaCodeFamille { get; set; }

    public string? ArRef { get; set; }

    public string? ArDesign { get; set; }

    public string? LsNoSerie { get; set; }

    public decimal? AsQteMini { get; set; }

    public decimal? AsQteMaxi { get; set; }

    public decimal? AsQteSto { get; set; }

    public decimal? LsQte { get; set; }

    public decimal? LsQteRestant { get; set; }
}

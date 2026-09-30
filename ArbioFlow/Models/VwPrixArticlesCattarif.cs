using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwPrixArticlesCattarif
{
    public string ArRef { get; set; } = null!;

    public string? ArDesign { get; set; }

    public string? CtIntitule { get; set; }

    public decimal? AcPrixVen { get; set; }
}

using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwAchatStock
{
    public string? FaIntitule { get; set; }

    public string ArRef { get; set; } = null!;

    public string? ArDesign { get; set; }

    public decimal? QteDate { get; set; }
}

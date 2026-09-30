using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwSeuilMinStock
{
    public DateTime Dateop { get; set; }

    public string DeIntitule { get; set; } = null!;

    public string ArRef { get; set; } = null!;

    public string? ArDesign { get; set; }

    public decimal? StockAdate { get; set; }

    public decimal? StockMinimum { get; set; }

    public decimal? StockMaximum { get; set; }
}

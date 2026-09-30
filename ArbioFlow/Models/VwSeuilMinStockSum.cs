using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwSeuilMinStockSum
{
    public DateTime? Dateop { get; set; }

    public string? CtNum { get; set; }

    public string? CtIntitule { get; set; }

    public string? ArRef { get; set; }

    public string? ArDesign { get; set; }

    public decimal? StockAdate { get; set; }

    public decimal? StockMinimum { get; set; }

    public decimal? StockMaximum { get; set; }
}

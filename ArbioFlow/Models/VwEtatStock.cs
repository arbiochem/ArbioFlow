using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwEtatStock
{
    public string? Site { get; set; }

    public string? Famille { get; set; }

    public string? Reference { get; set; }

    public string? Designation { get; set; }

    public string? CtNum { get; set; }

    public string? CtIntitule { get; set; }

    public string? Depot { get; set; }

    public decimal? StockReel { get; set; }

    public decimal? StockMini { get; set; }

    public decimal? StockMaxi { get; set; }

    public string Purchase { get; set; } = null!;

    public decimal? AfPrixAch { get; set; }
}

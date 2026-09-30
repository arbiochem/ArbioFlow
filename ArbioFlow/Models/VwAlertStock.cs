using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwAlertStock
{
    public string? CtNum { get; set; }

    public string? Reference { get; set; }

    public string? Designation { get; set; }

    public decimal AfPrixAch { get; set; }

    public string? Famille { get; set; }

    public string? CtIntitule { get; set; }

    public decimal? ArbiochemStockReel { get; set; }

    public decimal? ArbiochemStockMini { get; set; }

    public decimal? ArbiochemStockMaxi { get; set; }
}

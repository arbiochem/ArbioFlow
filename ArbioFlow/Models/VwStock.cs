using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwStock
{
    public DateTime? DoDate { get; set; }

    public string? Reference { get; set; }

    public string? Designation { get; set; }

    public string? Depot { get; set; }

    public decimal? StockActuel { get; set; }

    public decimal? StockMini { get; set; }

    public decimal? StockMaxi { get; set; }
}

using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwMvtStockDepot
{
    public string? Domaine { get; set; }

    public string Type { get; set; } = null!;

    public DateTime? DoDate { get; set; }

    public string? DoPiece { get; set; }

    public string? DoTiers { get; set; }

    public string? DepotInit { get; set; }

    public string? DepotDest { get; set; }
}

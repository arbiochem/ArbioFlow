using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVenteDashboard
{
    public string ProtUser { get; set; } = null!;

    public string? DoPiece { get; set; }

    public DateTime? DoDate { get; set; }

    public string? DoTiers { get; set; }

    public string? CtIntitule { get; set; }

    public decimal? DoTotalHt { get; set; }

    public decimal? DoTotalTtc { get; set; }

    public decimal? DoNetApayer { get; set; }

    public decimal? DoMontantRegle { get; set; }

    public string? ProtEmail { get; set; }
}

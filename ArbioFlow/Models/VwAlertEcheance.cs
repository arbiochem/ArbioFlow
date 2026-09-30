using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwAlertEcheance
{
    public string? Site { get; set; }

    public int? DrNo { get; set; }

    public DateTime? DoDate { get; set; }

    public string? DoPiece { get; set; }

    public string? DoTiers { get; set; }

    public string? CtIntitule { get; set; }

    public string? RIntitule { get; set; }

    public decimal? DoTotalTtc { get; set; }

    public DateTime? EchDate { get; set; }

    public decimal? DoMontantRegle { get; set; }

    public decimal? Reste { get; set; }

    public string DeIntitule { get; set; } = null!;
}

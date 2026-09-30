using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVenteJournalierDepot
{
    public string Depot { get; set; } = null!;

    public DateTime? LaDate { get; set; }

    public string? CodeClient { get; set; }

    public string? IntituleClient { get; set; }

    public string? Piece { get; set; }

    public string? Reference { get; set; }

    public string? Entete1 { get; set; }

    public decimal? DoTotalHtnet { get; set; }

    public decimal? NetApayer { get; set; }

    public DateTime? DrDate { get; set; }

    public decimal RcMontant { get; set; }

    public string? RIntitule { get; set; }

    public string? ProtUser { get; set; }

    public string? Site { get; set; }
}

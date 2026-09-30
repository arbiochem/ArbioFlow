using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVenteJournalierDepotBak
{
    public string Depot { get; set; } = null!;

    public DateTime? LaDate { get; set; }

    public string? CodeClient { get; set; }

    public string? IntituleClient { get; set; }

    public string? Piece { get; set; }

    public string? Reference { get; set; }

    public string? Entete1 { get; set; }

    public decimal? TotalTtc { get; set; }

    public decimal? NetApayer { get; set; }

    public DateTime? DateEcheance { get; set; }

    public string? ModePaiement { get; set; }
}

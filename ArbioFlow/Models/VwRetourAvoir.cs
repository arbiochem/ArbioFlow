using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwRetourAvoir
{
    public string? Depot { get; set; }

    public DateTime? LaDate { get; set; }

    public string? CodeClient { get; set; }

    public string? IntituleClient { get; set; }

    public string? DoProvenance { get; set; }

    public string? Piece { get; set; }

    public string? Reference { get; set; }

    public string? Entete1 { get; set; }

    public decimal? DoTotalHtnet { get; set; }

    public decimal? NetApayer { get; set; }
}

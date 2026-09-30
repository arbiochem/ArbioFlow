using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVenteParArticleMahitsy
{
    public string CliNum { get; set; } = null!;

    public string? CliIntitule { get; set; }

    public string ArtNum { get; set; } = null!;

    public string? ArtLib { get; set; }

    public decimal? Cahtnet { get; set; }

    public decimal? Cattcnet { get; set; }

    public decimal? QteVendues { get; set; }

    public string? VDocnum { get; set; }

    public DateTime? VDocdate { get; set; }

    public string? VDepot { get; set; }

    public int? VPk { get; set; }
}

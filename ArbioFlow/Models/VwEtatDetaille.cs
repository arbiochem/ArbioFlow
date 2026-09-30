using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwEtatDetaille
{
    public string CliNum { get; set; } = null!;

    public string? VDocnum { get; set; }

    public string? VDoref { get; set; }

    public DateTime? VDocdate { get; set; }

    public string ArtNum { get; set; } = null!;

    public string? ArtLib { get; set; }

    public decimal? Cahtnet { get; set; }

    public decimal? Cattcnet { get; set; }

    public string? CliIntitule { get; set; }

    public decimal? QteVendues { get; set; }
}

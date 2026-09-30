using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVenteCaChart
{
    public string? Site { get; set; }

    public string CliNum { get; set; } = null!;

    public string? VDocnum { get; set; }

    public string? VDoref { get; set; }

    public DateOnly? VDocdate { get; set; }

    public int? NumSemaine { get; set; }

    public int? NumMois { get; set; }

    public string ArtNum { get; set; } = null!;

    public string? ArtLib { get; set; }

    public string Fagroupe { get; set; } = null!;

    public decimal? CaHtNet { get; set; }

    public decimal? CaTtcNet { get; set; }

    public string? CliIntitule { get; set; }

    public decimal? QteVendues { get; set; }

    public string? Depot { get; set; }
}

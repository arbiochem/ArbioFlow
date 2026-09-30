using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVenteCaEpRefEntete
{
    public string? Site { get; set; }

    public string CliNum { get; set; } = null!;

    public string? VDocnum { get; set; }

    public DateTime? VDocdate { get; set; }

    public string? VDoref { get; set; }

    public string? VCoord01 { get; set; }

    public string? VCoord02 { get; set; }

    public string? VCoord03 { get; set; }

    public string? VCoord04 { get; set; }

    public string ArtNum { get; set; } = null!;

    public string? ArtLib { get; set; }

    public string Fagroupe { get; set; } = null!;

    public decimal? Cahtnet { get; set; }

    public decimal? Cattcnet { get; set; }

    public string? CliIntitule { get; set; }

    public decimal? QteVendues { get; set; }

    public string? VDepot { get; set; }
}

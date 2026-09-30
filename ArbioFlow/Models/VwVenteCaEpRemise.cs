using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVenteCaEpRemise
{
    public string? Site { get; set; }

    public int? NumSemaine { get; set; }

    public int? NumMois { get; set; }

    public string ArtNum { get; set; } = null!;

    public string? ArtLib { get; set; }

    public decimal? QteVendues { get; set; }

    public DateTime? VDocdate { get; set; }

    public string? VDocnum { get; set; }

    public string CliNum { get; set; } = null!;

    public string? CliIntitule { get; set; }

    public decimal? DlPuttc { get; set; }

    public decimal? VlPourcentremise { get; set; }

    public string VDepot { get; set; } = null!;
}

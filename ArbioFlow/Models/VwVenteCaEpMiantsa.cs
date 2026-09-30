using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVenteCaEpMiantsa
{
    public string? Site { get; set; }

    public string CliNum { get; set; } = null!;

    public string? VDocnum { get; set; }

    public string? VDoref { get; set; }

    public DateTime? VDocdate { get; set; }

    public int? NumSemaine { get; set; }

    public int? NumMois { get; set; }

    public string ArtFacodefamille { get; set; } = null!;

    public string ArtNum { get; set; } = null!;

    public string? ArtLib { get; set; }

    public string Fagroupe { get; set; } = null!;

    public decimal? Cahtnet { get; set; }

    public decimal? Cattcnet { get; set; }

    public string? CliIntitule { get; set; }

    public decimal? QteVendues { get; set; }

    public string? VDepot { get; set; }

    public string ProtUser { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVenteCaEpArticle
{
    public string? Site { get; set; }

    public string? VDocnum { get; set; }

    public DateTime? VDocdate { get; set; }

    public int? NumSemaine { get; set; }

    public string CliNum { get; set; } = null!;

    public string? CliIntitule { get; set; }

    public string? VDoref { get; set; }

    public string FaCodeFamille { get; set; } = null!;

    public string? FaIntitule { get; set; }

    public string ArtNum { get; set; } = null!;

    public string? ArtLib { get; set; }

    public decimal? DlPuttc { get; set; }

    public decimal? QteVendues { get; set; }

    public decimal? Cahtnet { get; set; }

    public decimal? Cattcnet { get; set; }

    public string VDepot { get; set; } = null!;
}

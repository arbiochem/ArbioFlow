using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VentesAggregatedDaily
{
    public long Id { get; set; }

    public string? Site { get; set; }

    public string? CliNum { get; set; }

    public string? VDocnum { get; set; }

    public string? VDocref { get; set; }

    public DateTime? VDocdate { get; set; }

    public int? NumSemaine { get; set; }

    public int? NumMois { get; set; }

    public string? ArtNum { get; set; }

    public string? ArtLib { get; set; }

    public string? Fagroupe { get; set; }

    public decimal? Cahtnet { get; set; }

    public decimal? Cattcnet { get; set; }

    public string? CliIntitule { get; set; }

    public decimal? QteVendues { get; set; }

    public string? VDepot { get; set; }

    public DateTime? DateCalcul { get; set; }

    public DateOnly? DateExecution { get; set; }
}

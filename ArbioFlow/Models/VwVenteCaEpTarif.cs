using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVenteCaEpTarif
{
    public string? Site { get; set; }

    public string? VDocnum { get; set; }

    public DateTime? VDocdate { get; set; }

    public int? NumSemaine { get; set; }

    public string CliNum { get; set; } = null!;

    public string? CliIntitule { get; set; }

    public string? VDoref { get; set; }

    public decimal? Pv0 { get; set; }

    public decimal? Pv1 { get; set; }

    public decimal? Pv2 { get; set; }

    public decimal? Pv3 { get; set; }

    public decimal? Pv4 { get; set; }

    public decimal? Pv5 { get; set; }
}

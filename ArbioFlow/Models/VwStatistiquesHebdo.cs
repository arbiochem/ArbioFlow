using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwStatistiquesHebdo
{
    public string? Societe { get; set; }

    public string Depot { get; set; } = null!;

    public DateTime? DoDate { get; set; }

    public string? CtNum { get; set; }

    public string? CtIntitule { get; set; }

    public string? ArRef { get; set; }

    public string? ArDesign { get; set; }

    public decimal? Qte { get; set; }

    public decimal? MontantHt { get; set; }

    public decimal? MontantTtc { get; set; }
}

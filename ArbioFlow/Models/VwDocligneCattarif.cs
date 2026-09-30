using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwDocligneCattarif
{
    public short DoType { get; set; }

    public DateTime? DoDate { get; set; }

    public string DoPiece { get; set; } = null!;

    public string? ArRef { get; set; }

    public short? AcCategorie { get; set; }

    public decimal? AcPrixVen { get; set; }

    public decimal? DlPrixUnitaire { get; set; }

    public int? DeNo { get; set; }

    public string? CtIntitule { get; set; }

    public string? Depot { get; set; }

    public string DeIntitule { get; set; } = null!;
}

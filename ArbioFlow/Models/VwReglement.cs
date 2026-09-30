using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwReglement
{
    public DateTime? RgDate { get; set; }

    public short? DoSouche { get; set; }

    public string? RgPiece { get; set; }

    public string? DoPiece { get; set; }

    public string? Client { get; set; }

    public string? RgReference { get; set; }

    public string? RgLibelle { get; set; }

    public decimal? RgMontant { get; set; }

    public string DeIntitule { get; set; } = null!;
}

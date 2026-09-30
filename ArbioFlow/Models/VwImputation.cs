using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwImputation
{
    public DateTime? DoDate { get; set; }

    public string? DoPiece { get; set; }

    public string? CtNumPayeur { get; set; }

    public string? RIntitule { get; set; }

    public decimal? DoTotalHt { get; set; }

    public DateTime? RgDate { get; set; }

    public string JoNum { get; set; } = null!;

    public string? RgLibelle { get; set; }

    public decimal? RcMontant { get; set; }

    public string? RgPiece { get; set; }

    public string DeIntitule { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class Reglement
{
    public int? RgNo { get; set; }

    public string? RgPiece { get; set; }

    public DateTime? RgDate { get; set; }

    public string? CtNumPayeur { get; set; }

    public string? CtIntitule { get; set; }

    public string? RgReference { get; set; }

    public string? RgLibelle { get; set; }

    public decimal? RgMontant { get; set; }

    public string JoNum { get; set; } = null!;

    public string? RIntitule { get; set; }
}

using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwImputationsReglement
{
    public string? Db { get; set; }

    public string DeIntitule { get; set; } = null!;

    public DateTime? RgDate { get; set; }

    public string? CtNumPayeur { get; set; }

    public string? CtIntitule { get; set; }

    public string JoNum { get; set; } = null!;

    public string? RgLibelle { get; set; }

    public string? RgReference { get; set; }

    public string? RgPiece { get; set; }

    public string? RIntitule { get; set; }

    public decimal? RgMontant { get; set; }

    public string? ProtUser { get; set; }

    public string? ProtDescription { get; set; }

    public string? CbModification1 { get; set; }

    public string? CbModification { get; set; }

    public int? RgNo { get; set; }
}

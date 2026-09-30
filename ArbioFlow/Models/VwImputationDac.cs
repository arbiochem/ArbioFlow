using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwImputationDac
{
    public string? Site { get; set; }

    public string? DoPiece { get; set; }

    public DateTime? DoDate { get; set; }

    public string? CtNumPayeur { get; set; }

    public string? CtIntitule { get; set; }

    public decimal? DoTotalHtnet { get; set; }

    public string? RgLibelle { get; set; }

    public string? RgReference { get; set; }

    public string? RgPiece { get; set; }

    public string? RIntitule { get; set; }

    public DateTime? RgDate { get; set; }

    public decimal? RgMontant { get; set; }

    public string? ProtUser { get; set; }

    public string? ProtDescription { get; set; }

    public int? RgNo { get; set; }
}

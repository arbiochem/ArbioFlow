using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwAuteurReglement
{
    public int? RgNo { get; set; }

    public string? CtNumPayeur { get; set; }

    public DateTime? RgDate { get; set; }

    public string? RgReference { get; set; }

    public string? RgLibelle { get; set; }

    public decimal? RgMontant { get; set; }

    public string ProtUser { get; set; } = null!;

    public string? ProtDescription { get; set; }

    public short? ProtRight { get; set; }
}

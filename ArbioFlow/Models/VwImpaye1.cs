using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwImpaye1
{
    public string? Site { get; set; }

    public DateTime? IDate { get; set; }

    public DateTime? IDatefacture { get; set; }

    public string? IPiece { get; set; }

    public string CtNum { get; set; } = null!;

    public string? CtIntitule { get; set; }

    public string? ITiers { get; set; }

    public string? IIntituletiers { get; set; }

    public string? ICg { get; set; }

    public string? IModeregl { get; set; }

    public decimal? IMontantdorigine { get; set; }

    public decimal? IMontantrestant { get; set; }

    public DateTime? IDateech { get; set; }

    public decimal? IMontantaregler { get; set; }

    public decimal? IRegleiMpute { get; set; }
}

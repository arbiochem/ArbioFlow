using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVerifDevisBl
{
    public short? DoType { get; set; }

    public DateTime? DoDate { get; set; }

    public string? DoPiece { get; set; }

    public decimal? DoTotalHtnet { get; set; }

    public string DeIntitule { get; set; } = null!;

    public string ProtUser { get; set; } = null!;
}

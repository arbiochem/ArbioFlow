using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVerifLotserie
{
    public short DoType { get; set; }

    public string? CtNum { get; set; }

    public string DoPiece { get; set; } = null!;

    public DateTime? DoDate { get; set; }

    public string? ArRef { get; set; }

    public string? DlDesign { get; set; }

    public int? DlLigne { get; set; }

    public int? DeNo { get; set; }

    public int? DlNo { get; set; }

    public short? DlMvtStock { get; set; }

    public string? Lotserie { get; set; }

    public decimal? DlQte { get; set; }
}

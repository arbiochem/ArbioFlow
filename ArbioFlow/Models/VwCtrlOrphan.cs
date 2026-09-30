using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwCtrlOrphan
{
    public string DoPiece { get; set; } = null!;

    public DateTime? DoDate { get; set; }

    public string? ArRef { get; set; }

    public int? NbSorties { get; set; }

    public int? NbEntrees { get; set; }
}

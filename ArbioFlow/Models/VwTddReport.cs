using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwTddReport
{
    public string DoPiece { get; set; } = null!;

    public DateTime? DoDate { get; set; }

    public string? DoRef { get; set; }

    public string Statut { get; set; } = null!;

    public string? ArRef { get; set; }

    public string? DlDesign { get; set; }

    public string Retenu { get; set; } = null!;

    public decimal? QteSortie { get; set; }

    public decimal? QteEntree { get; set; }
}

using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwTddReportNew
{
    public string DoPiece { get; set; } = null!;

    public DateTime? DoDate { get; set; }

    public int? Dd { get; set; }

    public string? Retard { get; set; }

    public string? DoRef { get; set; }

    public string? ArRef { get; set; }

    public string? DlDesign { get; set; }

    public string Statut { get; set; } = null!;

    public decimal? QteSortie { get; set; }

    public decimal? QteEntree { get; set; }

    public string Retenu { get; set; } = null!;

    public string? Cm { get; set; }
}

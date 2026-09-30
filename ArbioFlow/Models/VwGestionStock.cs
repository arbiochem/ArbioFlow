using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwGestionStock
{
    public string ArtSommeil { get; set; } = null!;

    public string? ArRef { get; set; }

    public string? DlDesign { get; set; }

    public string DoPiece { get; set; } = null!;

    public DateTime? DoDate { get; set; }

    public decimal? QteEntree { get; set; }

    public decimal? QteSortie { get; set; }

    public decimal? QteDeprStock { get; set; }

    public decimal? QteVirDep { get; set; }

    public decimal? QtePrepFab { get; set; }

    public decimal? QteOrdreFab { get; set; }

    public decimal? QteBonFab { get; set; }

    public string Unité { get; set; } = null!;

    public string DeIntitule { get; set; } = null!;
}

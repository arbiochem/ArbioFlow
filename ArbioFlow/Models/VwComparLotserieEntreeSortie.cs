using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwComparLotserieEntreeSortie
{
    public string DoPiece { get; set; } = null!;

    public DateTime? DoDate { get; set; }

    public string ArRef { get; set; } = null!;

    public DateTime? LsPeremption { get; set; }

    public DateTime? LsFabrication { get; set; }

    public string? LsNoSerie { get; set; }

    public int DeNo { get; set; }

    public int? DlNoIn { get; set; }

    public decimal? Entree { get; set; }

    public decimal? Sortie { get; set; }

    public decimal? Ecart { get; set; }
}

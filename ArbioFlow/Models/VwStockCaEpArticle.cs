using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwStockCaEpArticle
{
    public string? Site { get; set; }

    public DateTime? DoDate { get; set; }

    public string DoPiece { get; set; } = null!;

    public string? DoRef { get; set; }

    public string? ArRef { get; set; }

    public string? ArDesign { get; set; }

    public decimal? DlQte { get; set; }

    public string DeIntitule { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwMvtArticle
{
    public string? ArRef { get; set; }

    public int? DeNo { get; set; }

    public string DeIntitule { get; set; } = null!;

    public string DoPiece { get; set; } = null!;

    public DateTime? DoDate { get; set; }

    public decimal? Me { get; set; }

    public decimal? Mtin { get; set; }

    public decimal? Fr { get; set; }

    public decimal? Dv { get; set; }

    public decimal? Bl { get; set; }

    public decimal? Fc { get; set; }

    public decimal? Ms { get; set; }

    public decimal? Mtout { get; set; }

    public decimal? Entree { get; set; }

    public decimal? Sortie { get; set; }

    public decimal? Ecart { get; set; }
}

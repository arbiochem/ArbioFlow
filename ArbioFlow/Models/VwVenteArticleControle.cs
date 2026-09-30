using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVenteArticleControle
{
    public string? Db { get; set; }

    public string? Reference { get; set; }

    public string? Designation { get; set; }

    public DateTime? Ladate { get; set; }

    public string? Nclient { get; set; }

    public string? Nameclient { get; set; }

    public string Piece { get; set; } = null!;

    public string? Refpiece { get; set; }

    public decimal? Qte { get; set; }

    public decimal? Puttc { get; set; }

    public string Depot { get; set; } = null!;
}

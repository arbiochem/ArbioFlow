using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwWebStock
{
    public string? Site { get; set; }

    public string Depot { get; set; } = null!;

    public DateTime? DateDu { get; set; }

    public string Piece { get; set; } = null!;

    public string Reference { get; set; } = null!;

    public string? Designation { get; set; }

    public decimal StockInitial { get; set; }

    public decimal? Vente { get; set; }

    public decimal? Ms { get; set; }

    public decimal? Achat { get; set; }

    public decimal? Me { get; set; }

    public decimal? Mt { get; set; }

    public decimal? Autres { get; set; }

    public decimal StockActuel { get; set; }

    public decimal? StockMini { get; set; }

    public string? ProtUser { get; set; }
}

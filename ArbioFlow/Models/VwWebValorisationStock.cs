using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwWebValorisationStock
{
    public string? Mois { get; set; }

    public string? Artref { get; set; }

    public string? ValeurDuStock { get; set; }

    public decimal? Qtevendu { get; set; }

    public decimal? Cmup { get; set; }

    public decimal? Ca { get; set; }

    public decimal? Valstockvendu { get; set; }

    public decimal? Marge { get; set; }
}

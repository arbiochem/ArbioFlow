using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVenteCaRecap
{
    public DateTime? Ladate { get; set; }

    public string? Depot { get; set; }

    public string? Client { get; set; }

    public string? Famille { get; set; }

    public string? Article { get; set; }

    public decimal? Ca { get; set; }
}

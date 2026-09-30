using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class Cacp
{
    public string EcJonum { get; set; } = null!;

    public string? EcEcrefpiece { get; set; }

    public decimal? Montant { get; set; }

    public decimal? Taxe { get; set; }
}

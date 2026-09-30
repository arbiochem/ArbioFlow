using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwReglementCompar
{
    public string? CtNumPayeur { get; set; }

    public string? EcEcrefpiece { get; set; }

    public string? RgLibelle { get; set; }

    public DateTime? RgDate { get; set; }

    public DateTime? EcEcdate { get; set; }

    public decimal MontantCial { get; set; }

    public decimal MontantCpta { get; set; }

    public string? JoNum { get; set; }

    public string? EcJonum { get; set; }

    public decimal? Ecart { get; set; }
}

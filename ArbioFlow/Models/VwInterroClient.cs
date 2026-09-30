using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwInterroClient
{
    public string? SIntitule { get; set; }

    public string? EcJonum { get; set; }

    public DateTime? EcDateecriture { get; set; }

    public string? EcCtnum { get; set; }

    public string? EcEcpiece { get; set; }

    public string? EcEcrefpiece { get; set; }

    public string? EcEcreference { get; set; }

    public string? EcCgnum { get; set; }

    public string? EcEcintitule { get; set; }

    public DateTime? EcEcecheance { get; set; }

    public string? EcEclettre { get; set; }

    public decimal? EcEcmontantD { get; set; }

    public decimal? EcEcmontantC { get; set; }

    public decimal? Solde { get; set; }
}

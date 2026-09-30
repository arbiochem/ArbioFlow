using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwImpayeComptaFrn
{
    public string? Db { get; set; }

    public DateTime? EcDateecriture { get; set; }

    public string EcCgnum { get; set; } = null!;

    public string EcJonum { get; set; } = null!;

    public string? EcCtnum { get; set; }

    public string? CtIntitule { get; set; }

    public string? RIntitule { get; set; }

    public int EcEcno { get; set; }

    public string? EcEcpiece { get; set; }

    public string? EcEcrefpiece { get; set; }

    public string? EcEcintitule { get; set; }

    public decimal? EcEcmontantD { get; set; }

    public decimal? EcEcmontantC { get; set; }

    public decimal? Solde { get; set; }
}

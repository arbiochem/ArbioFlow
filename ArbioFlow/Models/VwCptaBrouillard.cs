using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwCptaBrouillard
{
    public DateTime? EcDateecriture { get; set; }

    public string? EcEcpiece { get; set; }

    public string EcCgnum { get; set; } = null!;

    public string EcJonum { get; set; } = null!;

    public string? EcEcintitule { get; set; }

    public decimal? EcEcmontantD { get; set; }

    public decimal? EcEcmontantC { get; set; }
}

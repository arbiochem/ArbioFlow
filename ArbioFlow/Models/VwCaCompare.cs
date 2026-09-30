using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwCaCompare
{
    public string? EcJonum { get; set; }

    public DateTime? VDocdate { get; set; }

    public DateTime? EcDateecriture { get; set; }

    public string? EcEcrefpiece { get; set; }

    public decimal? Montant { get; set; }

    public decimal? Cahtnet { get; set; }

    public decimal? Taxe { get; set; }

    public decimal? Tva { get; set; }

    public decimal? EcartMontant { get; set; }

    public decimal? EcartTaxe { get; set; }
}

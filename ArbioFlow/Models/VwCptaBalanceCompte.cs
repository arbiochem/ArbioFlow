using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwCptaBalanceCompte
{
    public string? Societe { get; set; }

    public string? CgNum { get; set; }

    public string? CgIntitule { get; set; }

    public decimal? SoldeDebitAnt { get; set; }

    public decimal? SoldeCreditAnt { get; set; }

    public decimal? DebitExo { get; set; }

    public decimal? CreditExo { get; set; }

    public decimal? SoldeDebitCumul { get; set; }

    public decimal? SoldeCreditCumul { get; set; }
}

using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwRotationStock
{
    public int? Position { get; set; }

    public string? Rubrique { get; set; }

    public int? Annee { get; set; }

    public decimal? Montant { get; set; }
}

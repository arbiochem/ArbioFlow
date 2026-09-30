using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVerifMiseajour
{
    public string EType { get; set; } = null!;

    public string? Societe { get; set; }

    public DateTime? DateDeRemise { get; set; }

    public int? IsComptabilise { get; set; }

    public string JoNum { get; set; } = null!;

    public string? Intitule { get; set; }

    public string? Reference { get; set; }

    public string? Mode { get; set; }

    public decimal? Montant { get; set; }

    public DateTime? DateDeSaisie { get; set; }

    public DateTime? DateDÉchéance { get; set; }
}

using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwPalmaresVenteClient
{
    public short? DoDomaine { get; set; }

    public short DoType { get; set; }

    public DateTime? DoDate { get; set; }

    public int? NumSemaine { get; set; }

    public int? Mois { get; set; }

    public string CtNum { get; set; } = null!;

    public string DeIntitule { get; set; } = null!;

    public string? CtIntitule { get; set; }

    public decimal? DlMontantTtc { get; set; }

    public decimal? DlQte { get; set; }
}

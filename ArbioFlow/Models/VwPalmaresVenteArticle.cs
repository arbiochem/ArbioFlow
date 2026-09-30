using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwPalmaresVenteArticle
{
    public string? Db { get; set; }

    public short? DoDomaine { get; set; }

    public short DoType { get; set; }

    public DateTime? DoDate { get; set; }

    public int? NumSemaine { get; set; }

    public int? Mois { get; set; }

    public string FaCodeFamille { get; set; } = null!;

    public string ArRef { get; set; } = null!;

    public string? ArDesign { get; set; }

    public string DeIntitule { get; set; } = null!;

    public decimal? DlMontantTtc { get; set; }

    public decimal? DlQte { get; set; }
}

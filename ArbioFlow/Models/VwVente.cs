using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVente
{
    public string? Site { get; set; }

    public DateTime? DoDate { get; set; }

    public string DoPiece { get; set; } = null!;

    public string? CtNum { get; set; }

    public string? CtIntitule { get; set; }

    public string? CtClassement { get; set; }

    public string? DoCoord04 { get; set; }

    public string? CtNumPayeur { get; set; }

    public string? CtIntitulePayeur { get; set; }

    public string? CtCodePostal { get; set; }

    public string? CtCodeRegion { get; set; }

    public string? CtVille { get; set; }

    public string? DoRef { get; set; }

    public string? ArRef { get; set; }

    public string? ArDesign { get; set; }

    public string? ArtGamme { get; set; }

    public decimal? DlQte { get; set; }

    public decimal? EuQte { get; set; }

    public string? UniteVente { get; set; }

    public string? Conditionnement { get; set; }

    public decimal? EcQuantite { get; set; }

    public decimal? QteConditionnement { get; set; }

    public string? Ardesign1 { get; set; }

    public decimal? DlPrixUnitaire { get; set; }

    public decimal? DlRemise01RemValeur { get; set; }

    public short? DlRemise01RemType { get; set; }

    public decimal? DlMontantHt { get; set; }

    public decimal? DlMontantTtc { get; set; }

    public short DoType { get; set; }

    public int? Annee { get; set; }

    public int? Mois { get; set; }
}

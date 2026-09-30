using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVenteCaArt
{
    public string? Societe { get; set; }

    public string? DeIntitule { get; set; }

    public DateTime? DoDate { get; set; }

    public string DoPiece { get; set; } = null!;

    public string? CtNum { get; set; }

    public string? CtIntitule { get; set; }

    public string? CtIntitulePayeur { get; set; }

    public string? ArRef { get; set; }

    public string? ArDesign { get; set; }

    public string? Famille { get; set; }

    public decimal? DlQte { get; set; }

    public string? UniteVente { get; set; }

    public string? Ardesign1 { get; set; }

    public decimal? DlPrixUnitaire { get; set; }

    public decimal? DlMontantHt { get; set; }

    public decimal? DlMontantTtc { get; set; }
}

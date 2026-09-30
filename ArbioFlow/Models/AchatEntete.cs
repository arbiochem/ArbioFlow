using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class AchatEntete
{
    public short? DoType { get; set; }

    public short? DoImprim { get; set; }

    public string? AType { get; set; }

    public short? DoStatut { get; set; }

    public string? Etat { get; set; }

    public string? DoPiece { get; set; }

    public string? DoRef { get; set; }

    public DateTime? DoDate { get; set; }

    public string? DoTiers { get; set; }

    public string? CtIntitule { get; set; }

    public string? Acheteur { get; set; }

    public short? DoExpedit { get; set; }

    public DateTime? DoDateLivr { get; set; }

    public string? DoCoord01 { get; set; }

    public int? CoNo { get; set; }

    public int? DeNo { get; set; }

    public string? DeIntitule { get; set; }

    public decimal? DoTaxe1 { get; set; }

    public string? DoCodeTaxe1 { get; set; }

    public decimal? DoCours { get; set; }

    public decimal DoTotalHt { get; set; }

    public decimal DoTotalTtc { get; set; }
}

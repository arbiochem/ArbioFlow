using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class JobMvtStockHebdo
{
    public string? Societe { get; set; }

    public int? Annee { get; set; }

    public DateTime? DateDu { get; set; }

    public int? NumSemaine { get; set; }

    public int? DlNo { get; set; }

    public string? CodeArticle { get; set; }

    public string? Piece { get; set; }

    public string? DoRef { get; set; }

    public string? Designation { get; set; }

    public int? StockInitial { get; set; }

    public int? Vente { get; set; }

    public int? Ms { get; set; }

    public int? Achat { get; set; }

    public int? Me { get; set; }

    public int? Mt { get; set; }

    public int? Autres { get; set; }

    public decimal? Pu { get; set; }

    public decimal? MontantHt { get; set; }

    public int? StockFinal { get; set; }

    public decimal? CoherenceDeMarge { get; set; }

    public string? Depot { get; set; }

    public string? CtNum { get; set; }

    public string? Tiers { get; set; }

    public string? Observation { get; set; }
}

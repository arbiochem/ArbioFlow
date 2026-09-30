using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwImpayeOk
{
    public int? DrNo { get; set; }

    public DateTime? Date { get; set; }

    public string? DoPiece { get; set; }

    public string? NCompteClient { get; set; }

    public string? IntutiléClient { get; set; }

    public string? ModeDePayment { get; set; }

    public decimal? TotalÀPayer { get; set; }

    public DateTime? DateDImputation { get; set; }

    public decimal? MontantPayé { get; set; }

    public decimal? ResteÀPayer { get; set; }

    public decimal? CtEncours { get; set; }

    public string EtatDeRèglementDeVente { get; set; } = null!;

    public short? DrTypeRegl { get; set; }

    public string DeIntitule { get; set; } = null!;
}

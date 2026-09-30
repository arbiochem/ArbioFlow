using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwImpayeValide
{
    public DateTime? Startdate { get; set; }

    public string? Site { get; set; }

    public string? NCompteClient { get; set; }

    public string? IntituléClient { get; set; }

    public decimal? EncoursAutorisé { get; set; }

    public short? DélaiDeRèglement { get; set; }

    public DateTime? Date { get; set; }

    public string? DoPiece { get; set; }

    public DateTime? Ech { get; set; }

    public string? EtatDeRèglementDeVente { get; set; }

    public decimal? TotalÀPayer { get; set; }

    public decimal? ResteÀPayer { get; set; }
}

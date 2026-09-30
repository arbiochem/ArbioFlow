using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwDocRegl
{
    public string? Site { get; set; }

    public string? NCompteClient { get; set; }

    public string? IntituléClient { get; set; }

    public decimal EncoursAutorisé { get; set; }

    public short DélaiDeRèglement { get; set; }

    public DateTime? Date { get; set; }

    public string? DoPiece { get; set; }

    public string? Ech { get; set; }

    public decimal TotalÀPayer { get; set; }

    public decimal ResteÀPayer { get; set; }

    public decimal MontantImputéSurÉchéance { get; set; }

    public string? Etatregl { get; set; }

    public DateTime? CbModification { get; set; }
}

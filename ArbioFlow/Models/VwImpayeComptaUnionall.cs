using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwImpayeComptaUnionall
{
    public string? Db { get; set; }

    public string? DeIntitule { get; set; }

    public int? DrNo { get; set; }

    public DateTime? Date { get; set; }

    public string? DoPiece { get; set; }

    public string? NCompteClient { get; set; }

    public string? IntutiléClient { get; set; }

    public string? ModeDePayment { get; set; }

    public string? JoNum { get; set; }

    public decimal MontantImputé { get; set; }

    public decimal? TotalÀPayer { get; set; }

    public DateTime? Echeance { get; set; }

    public decimal? MontantPayé { get; set; }

    public decimal? ResteÀPayer { get; set; }

    public DateTime? RgDate { get; set; }

    public string? RéférencePayement { get; set; }

    public string? Utilisateur { get; set; }

    public string? Profil { get; set; }

    public string? RgPiece { get; set; }

    public decimal? Solde { get; set; }
}

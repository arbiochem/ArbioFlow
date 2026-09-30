using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class FComptetJournal
{
    public int JournalId { get; set; }

    public string? CtNum { get; set; }

    public string? CtIntitule { get; set; }

    public DateTime? DateAction { get; set; }

    public string? ActionType { get; set; }

    public string? Colonne { get; set; }

    public string? AncienneValeur { get; set; }

    public string? NouvelleValeur { get; set; }

    public string? Utilisateur { get; set; }

    public string? Loginame { get; set; }
}

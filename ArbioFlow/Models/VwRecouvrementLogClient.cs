using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwRecouvrementLogClient
{
    public int JournalId { get; set; }

    public string? CtNum { get; set; }

    public string? CtIntitule { get; set; }

    public string? ActionType { get; set; }

    public DateTime? DateAction { get; set; }

    public string? AncienNRisque { get; set; }

    public string? NouveauNRisque { get; set; }

    public decimal? AncienCtEncours { get; set; }

    public decimal? NouveauCtEncours { get; set; }

    public string? AncienCtControlEnc { get; set; }

    public string? NouveauCtControlEnc { get; set; }

    public string? Utilisateur { get; set; }

    public string? Loginame { get; set; }
}

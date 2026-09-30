using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VentesHistorique
{
    public long HistId { get; set; }

    public DateOnly? DateDebut { get; set; }

    public DateOnly? DateFin { get; set; }

    public int? NbLignesInseres { get; set; }

    public int? DureeExecutionSec { get; set; }

    public DateTime? DateExecution { get; set; }

    public string? Statut { get; set; }
}

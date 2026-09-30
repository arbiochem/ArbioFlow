using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwCtrlLotserie
{
    public string Point { get; set; } = null!;

    public string ArRef { get; set; } = null!;

    public string? LsNoSerie { get; set; }

    public DateTime? LsPeremption { get; set; }

    public DateTime? LsFabrication { get; set; }

    public decimal? LsQte { get; set; }

    public int DeNo { get; set; }

    public int? DlNoIn { get; set; }

    public short? LsMvtStock { get; set; }

    public DateTime? Newvalue { get; set; }

    public string Newvaluelotserie { get; set; } = null!;

    public string Test { get; set; } = null!;

    public int CbMarq { get; set; }

    public DateTime? CbCreation { get; set; }
}

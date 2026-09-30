using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwCtrlFabrication
{
    public string? DoPiece { get; set; }

    public DateTime? DoDate { get; set; }

    public string? Point { get; set; }

    public string? ArRef { get; set; }

    public string? LsNoSerie { get; set; }

    public DateTime? LsPeremption { get; set; }

    public DateTime? LsFabrication { get; set; }

    public decimal? LsQte { get; set; }

    public int? DeNo { get; set; }

    public int? DlNoIn { get; set; }

    public short? LsMvtStock { get; set; }

    public DateTime? Newvalue { get; set; }

    public string? Newvaluelotserie { get; set; }

    public string? Test { get; set; }

    public int? CbMarq { get; set; }

    public DateTime? CbCreation { get; set; }
}

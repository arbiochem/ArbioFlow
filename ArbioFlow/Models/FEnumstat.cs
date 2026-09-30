using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class FEnumstat
{
    public short? NStatistique { get; set; }

    public string? EsIntitule { get; set; }

    public byte[]? CbEsIntitule { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public DateTime? CbCreation { get; set; }

    public Guid? CbCreationUser { get; set; }
}

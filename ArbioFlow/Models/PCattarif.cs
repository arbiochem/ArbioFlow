using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class PCattarif
{
    public string? CtIntitule { get; set; }

    public short? CtPrixTtc { get; set; }

    public short? CbIndice { get; set; }

    public int CbMarq { get; set; }
}

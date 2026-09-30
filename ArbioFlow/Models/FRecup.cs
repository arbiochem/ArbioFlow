using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class FRecup
{
    public string? Reference { get; set; }

    public DateOnly? LsPeremption { get; set; }

    public string? LsLot { get; set; }

    public int? Depot { get; set; }

    public int? Cbmarq { get; set; }
}

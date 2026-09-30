using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class FactureAchatSequence
{
    public string Prefix { get; set; } = null!;

    public int? CurrentNumber { get; set; }

    public int Year { get; set; }
}

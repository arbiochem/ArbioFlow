using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class ArbAchatDopiece
{
    public int? Rang { get; set; }

    public string Prefix { get; set; } = null!;

    public int? CurrentNumber { get; set; }

    public int Year { get; set; }
}

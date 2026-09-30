using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class PRecouvrement
{
    public string? JoNumProv { get; set; }

    public int? PiNoProvDotation { get; set; }

    public int? PiNoProvReprise { get; set; }

    public string? CgNumPerte { get; set; }

    public string? CgNumDouteux { get; set; }

    public int CbMarq { get; set; }
}

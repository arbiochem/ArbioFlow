using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class CbRegFile
{
    public short CbSession { get; set; }

    public string CbFile { get; set; } = null!;
}

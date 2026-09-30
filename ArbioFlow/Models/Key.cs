using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class Key
{
    public short Version { get; set; }

    public string CbType { get; set; } = null!;

    public short UsageKey { get; set; }

    public byte[] SKey { get; set; } = null!;
}

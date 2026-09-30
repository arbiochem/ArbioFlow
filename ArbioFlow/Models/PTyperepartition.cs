using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class PTyperepartition
{
    public int RpNum { get; set; }

    public string? RpIntitule { get; set; }

    public virtual ICollection<FDocfraisimport> FDocfraisimports { get; set; } = new List<FDocfraisimport>();
}

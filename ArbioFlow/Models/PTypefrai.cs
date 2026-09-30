using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class PTypefrai
{
    public int FrNum { get; set; }

    public string FrIntitule { get; set; } = null!;

    public int? FrParentId { get; set; }

    public virtual ICollection<FDocfraisimport> FDocfraisimports { get; set; } = new List<FDocfraisimport>();
}

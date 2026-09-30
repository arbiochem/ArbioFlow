using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwAccesParDepot
{
    public string ProtUser { get; set; } = null!;

    public string? ProtEmail { get; set; }

    public bool? Authorized { get; set; }

    public string DeIntitule { get; set; } = null!;
}

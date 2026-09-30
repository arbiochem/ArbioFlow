using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class DpCodeAffaireVente
{
    public string CavCode { get; set; } = null!;

    public string? CavInitule { get; set; }

    public string? CavNiveauAnalyse { get; set; }

    public string? CavPlanAnalytique { get; set; }

    public string CavCodeAffaire { get; set; } = null!;
}

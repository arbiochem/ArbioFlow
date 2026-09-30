using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVenteArticleClient
{
    public string? DésignationArticle { get; set; }

    public DateTime? Date { get; set; }

    public string NCompteClient { get; set; } = null!;

    public string? IntituléClient { get; set; }

    public string? NPièce { get; set; }

    public string? Référence { get; set; }

    public decimal? QteVendues { get; set; }

    public decimal? DlPuttc { get; set; }

    public string? VDepot { get; set; }
}

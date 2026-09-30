using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVenteCaNew
{
    public DateTime? Ladate { get; set; }

    public string Site { get; set; } = null!;

    public string? Depot { get; set; }

    public string? Client { get; set; }

    public string? Famille { get; set; }

    public string? ArRef { get; set; }

    public string? Article { get; set; }

    public decimal? DlQte { get; set; }

    public string? Unite { get; set; }

    public decimal? Ca { get; set; }
}

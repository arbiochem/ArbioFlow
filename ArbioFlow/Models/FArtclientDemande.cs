using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class FArtclientDemande
{
    public int Id { get; set; }

    public string DataSource { get; set; } = null!;

    public string Catalog { get; set; } = null!;

    public string? ArRef { get; set; }

    public string? Designation { get; set; }

    public string? Categorie { get; set; }

    public decimal AncienPrix { get; set; }

    public decimal? NouveauPrix { get; set; }

    public string UserName { get; set; } = null!;

    public string? UserRole { get; set; }

    public DateTime Hdate { get; set; }

    public bool Envoimail { get; set; }

    public bool Updated { get; set; }
}

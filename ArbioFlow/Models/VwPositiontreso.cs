using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwPositiontreso
{
    public string? Societe { get; set; }

    public string? Banque { get; set; }

    public string? Abrege { get; set; }

    public string? Devise { get; set; }

    public string? Rib { get; set; }

    public string? Jonum { get; set; }

    public DateTime? Dateop { get; set; }

    public decimal? SoldeExtrait { get; set; }

    public decimal? Encaissementdevise { get; set; }

    public decimal? Decaissementdevise { get; set; }

    public decimal? Encaissement { get; set; }

    public decimal? Decaissement { get; set; }

    public decimal? Ligne { get; set; }

    public string? TauxDInteret { get; set; }

    public string? GarantiesCautions { get; set; }

    public string? Echeance { get; set; }

    public string? Obs { get; set; }

    public decimal? Soldear { get; set; }

    public decimal? Soldedevise { get; set; }
}

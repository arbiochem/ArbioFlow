using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwVenteCaEpFamille
{
    public string Groupe { get; set; } = null!;

    public string? Site { get; set; }

    public string CodeClient { get; set; } = null!;

    public string? IntituleClient { get; set; }

    public string? Piece { get; set; }

    public string? Reference { get; set; }

    public DateTime? LaDate { get; set; }

    public int? NumSemaine { get; set; }

    public int? NumMois { get; set; }

    public string FaCodeFamille { get; set; } = null!;

    public string? FaIntitule { get; set; }

    public string ArtNum { get; set; } = null!;

    public string? ArtLib { get; set; }

    public decimal? Cahtnet { get; set; }

    public decimal? Cattcnet { get; set; }

    public decimal? QteVendues { get; set; }

    public string? VDepot { get; set; }

    public string Agence { get; set; } = null!;
}

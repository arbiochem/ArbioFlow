using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwCaCategorieTarifaireDocligne
{
    public short? DoDomaine { get; set; }

    public string? DoPiece { get; set; }

    public DateTime? DoDate { get; set; }

    public string? ArRef { get; set; }

    public string? DlDesign { get; set; }

    public decimal? DlQte { get; set; }

    public decimal? DlPrixUnitaire { get; set; }

    public short? AcCategorie { get; set; }
}

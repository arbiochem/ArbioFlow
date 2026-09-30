using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwClientInfo
{
    public string? CtNum { get; set; }

    public string? CtIntitule { get; set; }

    public string? CtTelephone { get; set; }

    public string? CtIdentifiant { get; set; }

    public string? CtSiret { get; set; }

    public string? CtEmail { get; set; }

    public string? CtAdresse { get; set; }

    public string? CtComplement { get; set; }

    public string? CtCodePostal { get; set; }

    public string? CtVille { get; set; }

    public string? CtPays { get; set; }

    public decimal? CtEncours { get; set; }

    public short? RtNbJour { get; set; }

    public string CtControlEnc { get; set; } = null!;

    public string? RIntitule { get; set; }
}

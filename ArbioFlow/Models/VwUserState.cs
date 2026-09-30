using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwUserState
{
    public string? Societe { get; set; }

    public string CbType { get; set; } = null!;

    public string ProtUser { get; set; } = null!;

    public string? ProtDescription { get; set; }

    public string? SessionType { get; set; }

    public string? Type { get; set; }

    public string? ProtLastLoginDate { get; set; }

    public string Profil { get; set; } = null!;

    public string? Obser { get; set; }

    public string? UserActive { get; set; }
}

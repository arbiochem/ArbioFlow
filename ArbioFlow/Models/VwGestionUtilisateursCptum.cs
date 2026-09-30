using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwGestionUtilisateursCptum
{
    public string? Societe { get; set; }

    public string ProtUser { get; set; } = null!;

    public string? ProtDescription { get; set; }

    public string? Type { get; set; }

    public string? ProtLastLoginDate { get; set; }

    public string? UserEnabled { get; set; }

    public string? Action { get; set; }
}

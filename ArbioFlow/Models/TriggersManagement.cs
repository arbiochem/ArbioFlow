using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class TriggersManagement
{
    public int TriggersId { get; set; }

    public string? TriggersTable { get; set; }

    public string? TriggersIntitule { get; set; }

    public bool Arbiochem { get; set; }

    public bool Activo { get; set; }
}

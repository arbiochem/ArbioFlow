using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class TServerDepot
{
    public int Id { get; set; }

    public string? AddressIp { get; set; }

    public string? Bdd { get; set; }

    public bool Actif { get; set; }

    public string? Location { get; set; }
}

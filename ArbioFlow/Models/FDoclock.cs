using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class FDoclock
{
    public int CbMarq { get; set; }

    public string DoPiece { get; set; } = null!;

    public Guid UserGuid { get; set; }

    public string? UserName { get; set; }

    public DateTime? LockTime { get; set; }

    public DateTime? LastActivity { get; set; }

    public string? SessionId { get; set; }

    public string? Ipaddress { get; set; }
}

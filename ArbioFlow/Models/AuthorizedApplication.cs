using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class AuthorizedApplication
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public byte[] Token { get; set; } = null!;
}

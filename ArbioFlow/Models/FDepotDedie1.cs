using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class FDepotDedie1
{
    public int Id { get; set; }

    public int? DeNo { get; set; }

    public bool? Authorized { get; set; }

    public Guid? ProtGuid { get; set; }
}

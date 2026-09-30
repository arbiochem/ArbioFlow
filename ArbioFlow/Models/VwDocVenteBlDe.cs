using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwDocVenteBlDe
{
    public short? DoDomaine { get; set; }

    public short? DoType { get; set; }

    public DateTime? DoDate { get; set; }

    public string? DoPiece { get; set; }

    public string ProtUser { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class FFret
{
    public int Id { get; set; }

    public string? DoPiece { get; set; }

    public decimal DoPrix { get; set; }

    public decimal DoPoids { get; set; }

    public decimal DoMontant { get; set; }
}

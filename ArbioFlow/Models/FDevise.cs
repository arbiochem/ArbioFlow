using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class FDevise
{
    public int Id { get; set; }

    public string? Devise { get; set; }

    public decimal Valeur { get; set; }
}

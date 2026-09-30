using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class FArtclientHistory
{
    public int HistoryId { get; set; }

    public string? Site { get; set; }

    public string? DatabaseName { get; set; }

    public string? ArRef { get; set; }

    public int? AcCategorie { get; set; }

    public decimal? OldPrix { get; set; }

    public decimal? NewPrix { get; set; }

    public DateTime? ModificationDate { get; set; }

    public string? ModifiedBy { get; set; }
}

using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class FCmlien
{
    public int? DlNoOut { get; set; }

    public int? DlNoIn { get; set; }

    public decimal? CmQte { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public DateTime? CbCreation { get; set; }

    public Guid? CbCreationUser { get; set; }
}

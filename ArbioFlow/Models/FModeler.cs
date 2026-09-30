using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class FModeler
{
    public int MrNo { get; set; }

    public string? MrIntitule { get; set; }

    public byte[]? CbMrIntitule { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public DateTime? CbCreation { get; set; }

    public Guid? CbCreationUser { get; set; }

    public virtual ICollection<FComptet> FComptets { get; set; } = new List<FComptet>();

    public virtual ICollection<FEmodeler> FEmodelers { get; set; } = new List<FEmodeler>();
}

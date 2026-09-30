using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class CbSysAudit
{
    public int Id { get; set; }

    public string CbFile { get; set; } = null!;

    public int CbMarq { get; set; }

    public short CbTypeOperation { get; set; }

    public Guid? CbUser { get; set; }

    public DateTime? CbDateOperation { get; set; }

    public string? CbCreateur { get; set; }

    public string? CbIdDescription { get; set; }

    public string? CbValuesDescription { get; set; }
}

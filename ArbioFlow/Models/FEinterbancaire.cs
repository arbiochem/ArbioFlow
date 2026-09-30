using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class FEinterbancaire
{
    public string IbAfb { get; set; } = null!;

    public byte[]? CbIbAfb { get; set; }

    public short IbSens { get; set; }

    public string? EiDomaine { get; set; }

    public byte[]? CbEiDomaine { get; set; }

    public string? EiCodeFamille { get; set; }

    public byte[]? CbEiCodeFamille { get; set; }

    public string? EiCodeIso { get; set; }

    public byte[]? CbEiCodeIso { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public DateTime? CbCreation { get; set; }

    public Guid? CbCreationUser { get; set; }

    public virtual FInterbancaire FInterbancaire { get; set; } = null!;
}

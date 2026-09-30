using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class FAfficheurcaisse
{
    public int CaNo { get; set; }

    public short? AcAction { get; set; }

    public short? AcCadrage { get; set; }

    public string? AcTexte { get; set; }

    public short? AcNumOrdre { get; set; }

    public short? CbProt { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? CbReplication { get; set; }

    public short? CbFlag { get; set; }

    public DateTime? CbCreation { get; set; }

    public Guid? CbCreationUser { get; set; }

    public virtual FCaisse CaNoNavigation { get; set; } = null!;
}

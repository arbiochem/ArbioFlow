using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class VwDocligneProtectioncial
{
    public short? DoDomaine { get; set; }

    public short DoType { get; set; }

    public string? CtNum { get; set; }

    public string DoPiece { get; set; } = null!;

    public DateTime? DoDate { get; set; }

    public DateTime? CbCreation { get; set; }

    public string ProtUser { get; set; } = null!;

    public string? ProtDescription { get; set; }

    public string? ProtEmail { get; set; }

    public int? ProtUserProfil { get; set; }
}

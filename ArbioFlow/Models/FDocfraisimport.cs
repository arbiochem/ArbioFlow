using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class FDocfraisimport
{
    public int FiId { get; set; }

    public string DoPiece { get; set; } = null!;

    public decimal FiMontant { get; set; }

    public string? FiDevise { get; set; }

    public int? FiTypeFraisId { get; set; }

    public int FiRepartitionId { get; set; }

    public string? FiPiece { get; set; }

    public string? FiObservation { get; set; }

    public DateTime? CbModification { get; set; }

    public Guid? Username { get; set; }

    public decimal FiMontantAr { get; set; }

    public string? Flag1 { get; set; }

    public string? Flag2 { get; set; }

    public string? Flag3 { get; set; }

    public virtual PTyperepartition FiRepartition { get; set; } = null!;

    public virtual PTypefrai? FiTypeFrais { get; set; }
}

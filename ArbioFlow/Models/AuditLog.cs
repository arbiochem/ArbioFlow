using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class AuditLog
{
    public int Id { get; set; }

    public string? TableName { get; set; }

    public string? Piece { get; set; }

    public string? Champ { get; set; }

    public string? Action { get; set; }

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public Guid? CbCreationUser { get; set; }

    public DateTime? DateOperation { get; set; }
}

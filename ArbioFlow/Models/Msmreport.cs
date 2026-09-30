using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

/// <summary>
/// MSSQL Manager reports repository table. Please don&apos;t modify this table and its subobjects.;
/// </summary>
public partial class Msmreport
{
    public int Id { get; set; }

    public string Repalias { get; set; } = null!;

    public string Repname { get; set; } = null!;

    public byte[] Source { get; set; } = null!;
}

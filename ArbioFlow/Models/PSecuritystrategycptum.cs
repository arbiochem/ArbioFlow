using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class PSecuritystrategycptum
{
    public short? SecurPwdStrong { get; set; }

    public short? SecurPwdRenouv { get; set; }

    public short? SecurPwdComplex { get; set; }

    public short? SecurPwdChain { get; set; }

    public short? SecurPwdRequired { get; set; }

    public int CbMarq { get; set; }
}

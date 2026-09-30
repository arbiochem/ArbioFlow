using System;
using System.Collections.Generic;

namespace ArbioFlow.Models;

public partial class PEservice
{
    public short? EsEdifactureEsActif { get; set; }

    public short? EsEdifactureEsEdiCodeType { get; set; }

    public string? EsEdifactureEsEdiCode { get; set; }

    public string? EsEdifactureEsEdiCodeSage { get; set; }

    public int? EsEdifactureCdNo { get; set; }

    public string? EsEdifactureJoNum { get; set; }

    public int? EsEdifacturePiNo { get; set; }

    public short? EsSfb { get; set; }

    public short? EsPaymentsEsActif { get; set; }

    public Guid? EsPaymentsEsOrganisationId { get; set; }

    public Guid? EsPaymentsEsCompanyId { get; set; }

    public string? EsPaymentsEsEmail { get; set; }

    public short? EsPaymentsEsRappel { get; set; }

    public DateTime? EsPaymentsEsDateLastRegl { get; set; }

    public string? EsPaymentsJoNumStripe { get; set; }

    public string? EsPaymentsCgNumStripe { get; set; }

    public string? EsPaymentsJoNumPaypal { get; set; }

    public string? EsPaymentsCgNumPaypal { get; set; }

    public short? EsPaymentsEsFacture { get; set; }

    public DateTime? EsPaymentsEsDateLastReglCial { get; set; }

    public short? EsFinexkapEsActif { get; set; }

    public string? EsFinexkapJoNum { get; set; }

    public int? EsFinexkapPiNo { get; set; }

    public int CbMarq { get; set; }
}

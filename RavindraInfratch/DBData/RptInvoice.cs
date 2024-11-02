using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class RptInvoice
{
    public long InvoiceId { get; set; }

    public string? InvoiceNo { get; set; }

    public string? InvoiceDate { get; set; }

    public int? DestinationId { get; set; }

    public string? ShipmentNo { get; set; }

    public int? ConsignerId { get; set; }

    public string? Crdetails { get; set; }

    public int? ConsigneeId { get; set; }

    public string? Cedetails { get; set; }

    public int? ProductId { get; set; }

    public int? VehicleId { get; set; }

    public string? BookingType { get; set; }

    public int? TotalPackage { get; set; }

    public decimal? ProdWeight { get; set; }

    public string? RateType { get; set; }

    public decimal? Rate { get; set; }

    public decimal? GivenRate { get; set; }

    public decimal? FreightAmount { get; set; }

    public decimal? GivenFreightAmount { get; set; }

    public string? InvNo { get; set; }

    public double? BillAmount { get; set; }

    public string? Bilty { get; set; }

    public string? Remarks { get; set; }

    public string? TruckNo { get; set; }

    public string? ChassisNo { get; set; }

    public string? Rc { get; set; }

    public string? Owner { get; set; }

    public string? OwnerAddress { get; set; }

    public string? CompanyName { get; set; }

    public string? CopanyGstinNo { get; set; }

    public string? CompanyPhone { get; set; }

    public string? CompanyEmailId { get; set; }

    public string? BranchCity { get; set; }

    public string? CityName { get; set; }

    public string? Crname { get; set; }

    public string? Craddress { get; set; }

    public string? Crstate { get; set; }

    public string? Crmobile { get; set; }

    public string? CrGst { get; set; }

    public string? CrAadhar { get; set; }

    public string? Cename { get; set; }

    public string? Ceaddress { get; set; }

    public string? Cestate { get; set; }

    public string? Cemobile { get; set; }

    public string? CeGst { get; set; }

    public string? CeAadhar { get; set; }

    public string? ProductName { get; set; }

    public string? FldName { get; set; }

    public string CopyType { get; set; } = null!;

    public string? Address { get; set; }
}

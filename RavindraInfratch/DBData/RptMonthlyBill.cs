using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class RptMonthlyBill
{
    public long InvoiceId { get; set; }

    public string? InvoiceNo { get; set; }

    public string? InvoiceDate { get; set; }

    public string? BookingType { get; set; }

    public double? BillAmount { get; set; }

    public string? Bilty { get; set; }

    public int? TotalPackage { get; set; }

    public decimal? TotalChargeWeight { get; set; }

    public decimal? FreightAmount { get; set; }

    public int? CompanyId { get; set; }

    public string? Destination { get; set; }

    public string? Cename { get; set; }

    public string? Ceaddress { get; set; }

    public string? Cecity { get; set; }

    public string? Cestate { get; set; }

    public string? Cemobile { get; set; }

    public string? CeGst { get; set; }

    public string? Crname { get; set; }

    public string? Craddress { get; set; }

    public string? Crcity { get; set; }

    public string? Crstate { get; set; }

    public string? Crmobile { get; set; }

    public string? CrGst { get; set; }

    public string? Remarks { get; set; }

    public int? VehicleId { get; set; }

    public string? Rcm { get; set; }

    public string? Hsncode { get; set; }

    public string? CeAadhar { get; set; }

    public string? CrAadhar { get; set; }

    public string? Cancelled { get; set; }

    public string? FldName { get; set; }

    public int? ConsignerId { get; set; }

    public int? ConsigneeId { get; set; }

    public int? DestinationId { get; set; }

    public string? BillNo { get; set; }

    public string? BillDate { get; set; }

    public string? AccountName { get; set; }

    public int Id { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Mobile { get; set; }

    public string? GstinNo { get; set; }

    public string? AadharNo { get; set; }

    public string? CompanyName { get; set; }

    public string? CompanyAddress { get; set; }

    public string? CompanyCity { get; set; }

    public string? CompanyState { get; set; }

    public string? CompanyPhone { get; set; }

    public string? CompanyEmailId { get; set; }

    public string? CopanyGstinNo { get; set; }

    public string? InvNo { get; set; }

    public string? CompanyWebsite { get; set; }

    public string? Email { get; set; }

    public int? SumTotalPackage { get; set; }

    public decimal? SumTotalChargeWeight { get; set; }

    public double? SumBillAmount { get; set; }

    public string? Party { get; set; }

    public string? BranchName { get; set; }

    public string? BranchAddress { get; set; }

    public string? BranchCity { get; set; }

    public string? Phone { get; set; }

    public string? EmailId { get; set; }

    public string? Gst { get; set; }

    public string? TruckNo { get; set; }
}

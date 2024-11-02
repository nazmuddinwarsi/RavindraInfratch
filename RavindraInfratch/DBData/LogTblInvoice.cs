using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class LogTblInvoice
{
    public long InvoiceId { get; set; }

    public string? InvoiceNo { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public string? ShipmentNo { get; set; }

    public int? DestinationId { get; set; }

    public int? ConsignerId { get; set; }

    public int? ConsigneeId { get; set; }

    public int? ProductId { get; set; }

    public string? Hsncode { get; set; }

    public int? TotalPackage { get; set; }

    public decimal? TotalChargeWeight { get; set; }

    public string? RateType { get; set; }

    public decimal? Rate { get; set; }

    public decimal? GivenRate { get; set; }

    public decimal? FreightAmount { get; set; }

    public decimal? GivenFreightAmount { get; set; }

    public string? InvNo { get; set; }

    public string? Remarks { get; set; }

    public string? BookingType { get; set; }

    public string? Bilty { get; set; }

    public string? Cnsrbill { get; set; }

    public string? Rcm { get; set; }

    public int? CompanyId { get; set; }

    public int? VehicleId { get; set; }

    public int? DriverId { get; set; }

    public string? DriverName { get; set; }

    public string? DriverMobile { get; set; }

    public string? Dl { get; set; }

    public int? OwnerId { get; set; }

    public string? OwnerName { get; set; }

    public string? Printed { get; set; }

    public string? Cancelled { get; set; }

    public int? DeliveryNumber { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? EditedBy { get; set; }

    public DateTime? EditedDate { get; set; }

    public int? SessionId { get; set; }

    public int? BranchId { get; set; }

    public double? BillAmount { get; set; }

    public string? Deliverd { get; set; }
}

using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class RptSummary
{
    public string? BookingType { get; set; }

    public int? TotalPackage { get; set; }

    public decimal? TotalChargeWeight { get; set; }

    public double? BillAmount { get; set; }

    public string? StateName { get; set; }

    public int? SessionId { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public int? TotalBooking { get; set; }
}

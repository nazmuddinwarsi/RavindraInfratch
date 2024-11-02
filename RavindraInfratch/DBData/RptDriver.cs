using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class RptDriver
{
    public int? BranchId { get; set; }

    public string? AccountName { get; set; }

    public short AccountId { get; set; }

    public string? City { get; set; }

    public string? Mobile { get; set; }

    public string? Cperson { get; set; }

    public string? TruckNo { get; set; }

    public string? DriverType { get; set; }

    public string? Dl { get; set; }

    public int? VehicleId { get; set; }

    public string? Remarks { get; set; }

    public DateTime? EditedDate { get; set; }

    public short? EditedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public decimal? ProductRate { get; set; }
}

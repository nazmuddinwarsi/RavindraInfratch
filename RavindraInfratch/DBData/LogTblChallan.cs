using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class LogTblChallan
{
    public int ChallanId { get; set; }

    public int? BranchId { get; set; }

    public string? ChallanNo { get; set; }

    public DateTime? ChallanDate { get; set; }

    public string? TruckNo { get; set; }

    public string? DriverName { get; set; }

    public string? DriverAddress { get; set; }

    public string? OwnerName { get; set; }

    public string? OwnerAddress { get; set; }

    public string? EWayBillNo { get; set; }

    public string? ToName { get; set; }

    public string? ToAddress { get; set; }

    public int? TotalPackage { get; set; }

    public decimal? ActualWeight { get; set; }

    public decimal? ChargeWeight { get; set; }

    public decimal? TotalAmount { get; set; }

    public int? CompanyId { get; set; }

    public string? Printed { get; set; }

    public short? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public short? EditedBy { get; set; }

    public DateTime? EditedDate { get; set; }

    public int? SessionId { get; set; }

    public int? Cancel { get; set; }

    public virtual ICollection<LogTblChallanDetail> LogTblChallanDetails { get; set; } = new List<LogTblChallanDetail>();
}

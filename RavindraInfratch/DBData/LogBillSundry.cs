using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class LogBillSundry
{
    public int? BranchId { get; set; }

    public short SundryId { get; set; }

    public string? SundryName { get; set; }

    public decimal? DefaultValue { get; set; }

    public string? SundryType { get; set; }

    public string? RoundOff { get; set; }

    public string? RoundOffType { get; set; }

    public string? AmountAs { get; set; }

    public string? PercentOf { get; set; }

    public bool? Active { get; set; }

    public string? Enable { get; set; }

    public short? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public short? EditedBy { get; set; }

    public DateTime? EditedDate { get; set; }

    public string? Show { get; set; }

    public string? TType { get; set; }
}

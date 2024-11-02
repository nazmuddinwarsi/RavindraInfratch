using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class Salary
{
    public int Id { get; set; }

    public DateTime? SalaryDate { get; set; }

    public int? DriverId { get; set; }

    public double? Amount { get; set; }

    public string? Remarks { get; set; }

    public short? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public short? EditedBy { get; set; }

    public DateTime? EditedDate { get; set; }

    public int? BranchId { get; set; }
}

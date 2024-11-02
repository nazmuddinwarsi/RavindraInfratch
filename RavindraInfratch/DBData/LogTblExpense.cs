using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class LogTblExpense
{
    public long Id { get; set; }

    public int? BranchId { get; set; }

    public int ExpenseId { get; set; }

    public double? Amount { get; set; }

    public string? Remarks { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? EditedBy { get; set; }

    public DateTime? EditedDate { get; set; }
}

using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class LogTblReceipt
{
    public long Id { get; set; }

    public int? BranchId { get; set; }

    public int? Ref { get; set; }

    public DateTime? ReceiptDate { get; set; }

    public string? InvoiceNo { get; set; }

    public double? Amount { get; set; }

    public double? ReceiveAmount { get; set; }

    public double? Balance { get; set; }

    public string? Remarks { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? EditedBy { get; set; }

    public DateTime? EditedDate { get; set; }

    public int? SessionId { get; set; }

    public int? BankId { get; set; }
}

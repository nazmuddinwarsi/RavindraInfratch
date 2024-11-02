using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class PendingPayment
{
    public string? InvoiceNo { get; set; }

    public string? BillNo { get; set; }

    public double? Freightamount { get; set; }

    public double? Receiveamount { get; set; }

    public double? Balance { get; set; }

    public string? ReceiptDate { get; set; }

    public string? AccountName { get; set; }

    public int? BranchId { get; set; }

    public int? SessionId { get; set; }
}

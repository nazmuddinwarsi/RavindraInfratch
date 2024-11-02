using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class LogTblInvoiceDetail
{
    public long InvDetailId { get; set; }

    public long? HeaderId { get; set; }

    public int? InvWeight { get; set; }

    public string? InvNo { get; set; }

    public DateTime? InvDate { get; set; }

    public double? InvValue { get; set; }
}

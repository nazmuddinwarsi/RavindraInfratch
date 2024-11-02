using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class LogTblPara
{
    public int? SessionId { get; set; }

    public int? BranchId { get; set; }

    public int? CompanyId { get; set; }

    public int? BiltyNo { get; set; }

    public int? BillNo { get; set; }

    public int? ReceiptNo { get; set; }

    public int? PaymentRefNo { get; set; }

    public decimal? Cgst { get; set; }

    public decimal? Sgst { get; set; }

    public decimal? Igst { get; set; }

    public string? Dm { get; set; }

    public string? Dy { get; set; }

    public int? DExp { get; set; }

    public decimal? Gst { get; set; }

    public string? BillPreFix { get; set; }

    public int? MonthlyBillNo { get; set; }

    public int Id { get; set; }
}

using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class Payment
{
    public int Id { get; set; }

    public int? PaymentNo { get; set; }

    public DateTime? PaymentDate { get; set; }

    public int? AccountId { get; set; }

    public string? PayMode { get; set; }

    public int? BankId { get; set; }

    public string? PayType { get; set; }

    public decimal? Amount { get; set; }

    public string? Remarks { get; set; }

    public byte? BranchId { get; set; }

    public short? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public short? EditedBy { get; set; }

    public DateTime? EditedDate { get; set; }

    public int? SessionId { get; set; }
}

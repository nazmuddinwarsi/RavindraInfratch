using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class LogTblBillSundryDetail
{
    public int? HeaderId { get; set; }

    public string? VType { get; set; }

    public byte? SundryId { get; set; }

    public decimal? Value { get; set; }

    public decimal? Amount { get; set; }
}

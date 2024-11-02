using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class InvoiceSundry
{
    public string? SundryName { get; set; }

    public decimal? Amount { get; set; }

    public byte? SundryId { get; set; }

    public int? HeaderId { get; set; }
}

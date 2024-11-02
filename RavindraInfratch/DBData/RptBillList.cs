using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class RptBillList
{
    public int Id { get; set; }

    public string? BillNo { get; set; }

    public DateOnly? BillDate { get; set; }

    public string PartyType { get; set; } = null!;

    public string? AccountName { get; set; }

    public string? City { get; set; }

    public string? FromDate { get; set; }

    public string? ToDate { get; set; }

    public int? BranchId { get; set; }

    public int? SessionId { get; set; }

    public int? PartyId { get; set; }
}

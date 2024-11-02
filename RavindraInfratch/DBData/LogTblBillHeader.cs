using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class LogTblBillHeader
{
    public int Id { get; set; }

    public string? BillNo { get; set; }

    public DateTime? BillDate { get; set; }

    public string? BookType { get; set; }

    public string? PartyType { get; set; }

    public int? PartyId { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? BranchId { get; set; }

    public int? CompanyId { get; set; }

    public int? EditedBy { get; set; }

    public DateTime? EditedDate { get; set; }

    public int? SessionId { get; set; }

    public int? Cancel { get; set; }
}

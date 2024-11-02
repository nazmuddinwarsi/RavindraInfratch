using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class LogTblState
{
    public int Id { get; set; }

    public int? BranchId { get; set; }

    public int? StateId { get; set; }

    public string? StateName { get; set; }

    public string? StateCode { get; set; }

    public int? BillNo { get; set; }

    public int? SessionId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }
}

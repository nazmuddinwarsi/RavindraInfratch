using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class LogTblMaster
{
    public int Id { get; set; }

    public int? BranchId { get; set; }

    public string? FldName { get; set; }

    public string? MobileNo { get; set; }

    public string? TType { get; set; }

    public short? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public short? EditedBy { get; set; }

    public DateTime? EditedDate { get; set; }
}

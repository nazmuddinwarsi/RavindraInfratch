using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class LogTblUser
{
    public short UserId { get; set; }

    public int? BranchId { get; set; }

    public string? FldName { get; set; }

    public string? FldUserName { get; set; }

    public string? FldPassword { get; set; }

    public string? AccessType { get; set; }

    public string? Active { get; set; }

    public short? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public short? EditedBy { get; set; }

    public DateTime? EditedDate { get; set; }
}

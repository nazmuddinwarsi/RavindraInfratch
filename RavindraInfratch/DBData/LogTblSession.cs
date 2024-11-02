using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class LogTblSession
{
    public int Id { get; set; }

    public string? SessionName { get; set; }

    public short? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public short? EditedBy { get; set; }

    public DateTime? EditedDate { get; set; }
}

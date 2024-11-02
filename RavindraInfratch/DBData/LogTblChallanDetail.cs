using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class LogTblChallanDetail
{
    public int ChallanDetailId { get; set; }

    public int? HeaderId { get; set; }

    public int? InvoiceId { get; set; }

    public virtual LogTblChallan? Header { get; set; }
}

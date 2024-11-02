using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class RptState
{
    public int Id { get; set; }

    public string? State1 { get; set; }

    public string? StateCode { get; set; }

    public int? BranchId { get; set; }

    public int? SessionId { get; set; }

    public int? StateId { get; set; }
}

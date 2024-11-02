using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class BranchMaster
{
    public byte Id { get; set; }

    public string? BranchName { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Phone { get; set; }

    public string? EmailId { get; set; }

    public string? Gst { get; set; }

    public DateTime? CreatedDate { get; set; }
}

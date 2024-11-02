using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class Freight
{
    public int Id { get; set; }

    public DateTime? FreightDate { get; set; }

    public int? OwnerId { get; set; }

    public int? DestinationId { get; set; }

    public double? Advance { get; set; }

    public double? Weight { get; set; }

    public double? Amount { get; set; }

    public string? Remarks { get; set; }

    public short? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public short? EditedBy { get; set; }

    public DateTime? EditedDate { get; set; }

    public int? BranchId { get; set; }

    public int? SessionId { get; set; }
}

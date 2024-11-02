using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class Vehicle
{
    public short Id { get; set; }

    public int? BranchId { get; set; }

    public int? OwnerId { get; set; }

    public string? TruckNo { get; set; }

    public string? ChassisNo { get; set; }

    public string? Rc { get; set; }

    public short? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public short? EditedBy { get; set; }

    public DateTime? EditedDate { get; set; }
}

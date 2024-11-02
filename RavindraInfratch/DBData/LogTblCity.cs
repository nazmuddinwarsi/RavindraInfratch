using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class LogTblCity
{
    public int Id { get; set; }

    public int? BranchId { get; set; }

    public string? CityName { get; set; }

    public int? StateId { get; set; }

    public decimal? PerKgrate { get; set; }

    public decimal? MinAmount { get; set; }

    public short? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public short? EditedBy { get; set; }

    public DateTime? EditedDate { get; set; }
}

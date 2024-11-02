using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class RptCareOf
{
    public int Id { get; set; }

    public string? FldName { get; set; }

    public string? MobileNo { get; set; }

    public int? CityId { get; set; }

    public string? CityName { get; set; }

    public decimal? PerKgrate { get; set; }

    public decimal? MinAmount { get; set; }

    public decimal? PerPktRate { get; set; }

    public int? BranchId { get; set; }
}

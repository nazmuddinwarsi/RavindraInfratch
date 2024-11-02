using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class RptCityState
{
    public int Id { get; set; }

    public string? CityName { get; set; }

    public int? StateId { get; set; }

    public decimal? PerKgrate { get; set; }

    public decimal? MinAmount { get; set; }

    public int? BranchId { get; set; }

    public string? State { get; set; }

    public string? StateCode { get; set; }
}

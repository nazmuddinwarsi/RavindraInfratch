using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class Rptplot
{
    public int Id { get; set; }

    public int Projectid { get; set; }

    public string? ProjectName { get; set; }

    public int Properytid { get; set; }

    public string? TType { get; set; }

    public int BlockId { get; set; }

    public string? Block { get; set; }

    public int? Plots { get; set; }

    public string? PlotSize { get; set; }
}

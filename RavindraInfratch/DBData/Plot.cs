using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class Plot
{
    public int Id { get; set; }

    public int? Projectid { get; set; }

    public int? Propertyid { get; set; }

    public int? Blockid { get; set; }

    public int? Plots { get; set; }

    public string? PlotSize { get; set; }
}

using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class Photo
{
    public int Id { get; set; }

    public string? Ttype { get; set; }

    public string? Tpath { get; set; }

    public int? Purchaseid { get; set; }
}

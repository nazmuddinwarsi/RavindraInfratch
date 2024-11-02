using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class Saleteam
{
    public short Snrid { get; set; }

    public int Id { get; set; }

    public string? Saletype { get; set; }

    public short Accountid { get; set; }

    public string? Sponsorname { get; set; }

    public string? Accountname { get; set; }

    public string? Address { get; set; }

    public string? Mobile { get; set; }

    public string? Whatsapp { get; set; }

    public string? Propertydetails { get; set; }

    public string? ProjectName { get; set; }

    public string? Ttype { get; set; }

    public string? Block { get; set; }

    public string? Plotno { get; set; }

    public string? Aarajino { get; set; }

    public string? Plotsize { get; set; }

    public double? Finalamount { get; set; }

    public DateTime? Createddate { get; set; }
}

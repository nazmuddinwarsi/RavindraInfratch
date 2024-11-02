using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class RptAccount
{
    public int AccountId { get; set; }

    public string? Active { get; set; }

    public string? TType { get; set; }

    public string? AccountName { get; set; }

    public string? Gender { get; set; }

    public string? City { get; set; }

    public string? District { get; set; }

    public string? State { get; set; }

    public string? Mobile { get; set; }

    public string? WhatsApp { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Address2 { get; set; }

    public string? AadharFront { get; set; }

    public string? AadharBack { get; set; }

    public string? Panphoto { get; set; }

    public string? Photo { get; set; }

    public string? Sponsorname { get; set; }

    public int? Sponsorid { get; set; }

    public string? CreatedDate { get; set; }

    public double? Business { get; set; }
}

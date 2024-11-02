using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class LogTblCompany
{
    public byte CompanyId { get; set; }

    public string? CompanyName { get; set; }

    public string? CompanyAddress { get; set; }

    public string? CompanyCity { get; set; }

    public string? CompanyState { get; set; }

    public string? CompanyPhone { get; set; }

    public string? CompanyEmailId { get; set; }

    public string? CompanyWebsite { get; set; }

    public string? CompanyGstinNo { get; set; }

    public string? Smtpclient { get; set; }

    public string? Smtpemail { get; set; }

    public string? Smtppassword { get; set; }

    public bool? EnableSsl { get; set; }

    public short? Smtpport { get; set; }

    public string? ToEmailId { get; set; }
}

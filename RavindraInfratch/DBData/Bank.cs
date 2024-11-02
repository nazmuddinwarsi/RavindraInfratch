using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class Bank
{
    public long Id { get; set; }

    public string? Display { get; set; }

    public string? AccountName { get; set; }

    public string? AccountNo { get; set; }

    public string? BankName { get; set; }

    public string? Branch { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? BranchId { get; set; }
}

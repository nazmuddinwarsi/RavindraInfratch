using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class RptReceipt
{
    public int Id { get; set; }

    public string? Receiptno { get; set; }

    public string? Accountname { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? Address { get; set; }

    public string? Plot { get; set; }

    public string? Plotsize { get; set; }

    public string? Direction { get; set; }

    public string? Chauhaddi { get; set; }

    public string? Aarajino { get; set; }

    public string? Bankname { get; set; }

    public string? Branchname { get; set; }

    public string? Ifsc { get; set; }

    public string? Accountno { get; set; }

    public string? Cheque { get; set; }

    public DateTime? Chequedate { get; set; }

    public string? Upi { get; set; }

    public double? Finalamount { get; set; }

    public double? Receivedamount { get; set; }

    public double? Dueamount { get; set; }

    public DateTime? Createddate { get; set; }
}

using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class Sale
{
    public int Id { get; set; }

    public int? Sponsorid { get; set; }

    public int? Customerid { get; set; }

    public int? Projectid { get; set; }

    public int? Propertyid { get; set; }

    public int? Blockid { get; set; }

    public string? Plotno { get; set; }

    public string? Plotsize { get; set; }

    public string? Direction { get; set; }

    public string? Chauhaddi { get; set; }

    public string? Aarajino { get; set; }

    public string? Bankname { get; set; }

    public string? Branchname { get; set; }

    public string? Ifsc { get; set; }

    public string? Cheque { get; set; }

    public DateTime? Chequedate { get; set; }

    public string? Upi { get; set; }

    public double? Finalamount { get; set; }

    public double? Dueamount { get; set; }

    public double? Advanceamoutn { get; set; }

    public double? Sponsorcommision { get; set; }

    public string? Sbankname { get; set; }

    public string? Sbranchname { get; set; }

    public string? Sifsc { get; set; }

    public string? Scheque { get; set; }

    public DateTime? Schequedate { get; set; }

    public string? Supi { get; set; }

    public double? Sfinalcommission { get; set; }

    public string? Loancustomerfull { get; set; }

    public string? Loansalaryslip { get; set; }

    public string? Customerfeedback { get; set; }

    public DateTime? Createddate { get; set; }

    public DateTime? Editeddate { get; set; }

    public string? Accountno { get; set; }

    public string? Saccountno { get; set; }

    public string? Propertydetails { get; set; }

    public string? Saletype { get; set; }

    public double? Profit { get; set; }
}

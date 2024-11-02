using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class Purchase
{
    public int Id { get; set; }

    public int? Sponsorid { get; set; }

    public int? Accountid { get; set; }

    public string? Deed { get; set; }

    public string? Bankname { get; set; }

    public string? Branchname { get; set; }

    public string? Ifsc { get; set; }

    public string? Cheque { get; set; }

    public DateTime? Chequedate { get; set; }

    public string? Upi { get; set; }

    public string? Banknoc { get; set; }

    public string? Oldagreement { get; set; }

    public string? Shareholder { get; set; }

    public string? Khatauni { get; set; }

    public string? Agreementdeadline { get; set; }

    public string? Aarajino { get; set; }

    public double? Area { get; set; }

    public double Finalamount { get; set; }

    public double? Dueamount { get; set; }

    public double? Advanceamoutn { get; set; }

    public int? Advocateid { get; set; }

    public string? Stamp { get; set; }

    public string? Rasid { get; set; }

    public double? Courtfee { get; set; }

    public double? OtherFee { get; set; }

    public string? Lekhpalname { get; set; }

    public string? Lekhpalmobile { get; set; }

    public string? Inspection1356 { get; set; }

    public string? Inspection1291 { get; set; }

    public string? Sala12 { get; set; }

    public string? Najrinaksha { get; set; }

    public string? Khasra { get; set; }

    public DateTime? Createddate { get; set; }

    public DateTime? Editeddate { get; set; }

    public int? Process { get; set; }

    public string? BankAccount { get; set; }

    public int? FromAccountId { get; set; }

    public string? Advocatename { get; set; }

    public double? Advocatefee { get; set; }

    public int? Photoid { get; set; }
}

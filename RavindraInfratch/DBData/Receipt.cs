using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class Receipt
{
    public int Id { get; set; }

    public int? Receiptno { get; set; }

    public int? Sponsorid { get; set; }

    public int? Customerid { get; set; }

    public int? Projectid { get; set; }

    public int? Propertyid { get; set; }

    public int? Blockid { get; set; }

    public string? Plotno { get; set; }

    public double? Finalamount { get; set; }

    public double? Receivedamount { get; set; }

    public double? Dueamount { get; set; }

    public DateTime? Createddate { get; set; }

    public DateTime? Editeddate { get; set; }

    public int? Saleid { get; set; }
}

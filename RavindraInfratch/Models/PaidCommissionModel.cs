namespace RavindraInfratch.Models
{
	public class PaidCommissionModel
	{
		public int Id { get; set; }

		public int? Ref { get; set; }

		public int? Sponsorid { get; set; }
		public string SponsorName { get; set; }
		public int? AccountID { get; set; }
		public string? Accountname {  get; set; }
		public string Name { get; set; }
		public string Mobile { get; set; }
		public string Address { get; set; }

		public double? Amount { get; set; }
		public double? PaidAmount { get; set; }

		public DateTime? Createddate { get; set; }

		public string? Paymode { get; set; }

		public string? Bankname { get; set; }

		public string? Branchname { get; set; }

		public string? Ifsc { get; set; }

		public string? Cheque { get; set; }

		public DateTime? Chequedate { get; set; }

		public string? Upi { get; set; }

		public string? AccountNo { get; set; }

		public string? Utr { get; set; }
	}
}

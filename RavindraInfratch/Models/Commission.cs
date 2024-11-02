namespace RavindraInfratch.Models
{
	public class Commission
	{
		public int Id { get; set; }
		public string AccountName { get; set; }
		public string Mobile { get; set; }
		public string WhatsApp { get; set; }
		public double PurchaseCommission {  get; set; }
		public double? SaleCommission { get; set; }
		public double? PaidCommission { get; set; }
		public double? TobePaidCommission { get; set; }

	}
}

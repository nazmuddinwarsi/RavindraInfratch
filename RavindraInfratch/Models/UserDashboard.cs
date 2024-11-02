namespace RavindraInfratch.Models
{
	public class UserDashboard
	{
		public short AccountID { get; set; }
		public string AccountName { get; set; }
		public double? Business { get; set; }
		public string Photo { get; set; }
		public string tTYPE { get; set; }
		public List<UserDashboard> BusinessMonth {  get; set; }

	}
}

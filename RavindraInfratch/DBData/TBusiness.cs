using System.ComponentModel.DataAnnotations;

namespace RavindraInfratch.DBData
{
	public class TBusiness
	{
		[Key]
		public string AccountName { get; set; }
		public string T { get; set; }
		public string Photo { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;
namespace RavindraInfratch.Models
{
	public class StateList
	{
		 
		public long Id { get; set; }
		[Required(ErrorMessage = "State Name is must !")]
		public string? State1 { get; set; }
		[Required(ErrorMessage = "State Code is must !")]
		public string? StateCode { get; set; }
	}
}

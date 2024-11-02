using System.ComponentModel.DataAnnotations;

namespace RavindraInfratch.Models
{
	public class AllProject
	{
		 
		public int AutoId { get; set; }
		[Required(ErrorMessage ="Please Enter Project Name")]
		public string? ProjectName { get; set; }
	}
}

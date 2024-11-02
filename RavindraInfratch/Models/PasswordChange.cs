using System.ComponentModel.DataAnnotations;

namespace RavindraInfratch.Models
{
	public class PasswordChange
	{
		[Key]
		public int AccountId { get; set; }

	
		[Required(ErrorMessage = "Old Password is required")]
		[Compare("GetOldPassword",ErrorMessage ="Old password is invaild")]
		public string? OldPassword { get; set; }
		[Required(ErrorMessage = "Password is required")]
		public string? Password { get; set; }
		[Required(ErrorMessage = "Confirm Password is required")]
		[Compare("Password")]
		public string? ConfirmPassword { get; set; }
		public string? GetOldPassword { get; set; }




	}
}

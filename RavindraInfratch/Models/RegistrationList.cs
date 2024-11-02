using System.ComponentModel.DataAnnotations;

namespace RavindraInfratch.Models
{
	public class RegistrationList
	{
		[Key]
		public int AccountId { get; set; }

		public string? TType { get; set; }
		[Required(ErrorMessage = "Please enter name")]
		public string? AccountName { get; set; }

		public string? Cperson { get; set; }
		public string? Gender { get; set; }

		public string? Address { get; set; }

		public string? Address2 { get; set; }

		public string? City { get; set; }
		public string? District { get; set; }
		[Range(1, 30, ErrorMessage = "Please Select State")]
		public string? State { get; set; }
		public string?StateName {  get; set; }
		[Required(ErrorMessage = "Please Enter Mobile No.")]
		[RegularExpression("^[6-9]\\d{9}$", ErrorMessage = "Mobile number is invalid")]
		public string? Mobile { get; set; }
		[Required(ErrorMessage = "Please Enter WhatsApp No.")]
		[RegularExpression("^[6-9]\\d{9}$", ErrorMessage = "WhatsApp number is invalid")]
		public string? WhatsApp { get; set; }

		public string? Email { get; set; }

		public string? AadharNo { get; set; }
		//[Required(ErrorMessage = "Please select Aadhar Front Photo")]
		public string? AadharFront { get; set; }
		
		public IFormFile? imgAadharFront { get; set; }


		public string? AadharBack { get; set; }
		//[Required(ErrorMessage ="Please select Aadhar Back Photo")]
		public IFormFile? imgAadharBack { get; set; }
		public string? Pan { get; set; }

		public string? Panphoto { get; set; }
		//[Required(ErrorMessage ="Please Select PAN Photo")]
		public IFormFile? imgPan { get; set; }

		public string? Photo { get; set; }
		//[Required(ErrorMessage ="Please select Photo")]
		//[Display(Name ="Choose your photo")]
		public IFormFile? imgPhoto { get; set; }

		public double? Salary { get; set; }

		public short? CreatedBy { get; set; }

		public DateTime? CreatedDate { get; set; }
		public string? DateString {  get; set; }

		public short? EditedBy { get; set; }

		public DateTime? EditedDate { get; set; }

		public string? Remarks { get; set; }

		public string? UserName { get; set; }

		public string? Password { get; set; }
		 

		[Required]
		[Range(0,3000,ErrorMessage ="Please Select Sponsor")]
		public string? SponsorID { get; set;}
		 
		 
		public string? SponsorName { get; set; }
		public string? Active {  get; set; }
		
	}
}

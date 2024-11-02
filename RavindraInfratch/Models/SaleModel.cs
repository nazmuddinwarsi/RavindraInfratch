using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RavindraInfratch.Models
{
	public class SaleModel
	{
		public int Id { get; set; }
		 

		[Range(1, 100000, ErrorMessage = "Please Select Sponsor")]
		public int? Sponsorid { get; set; }
		 public int receiptno { get; set; }
		public string Saletype { get; set; }
		public string? SponsorName { get; set; }
		public string? SAddress { get; set; }
		public string? SMobile { get; set; }
		[Required(ErrorMessage = "Please Enter Commission")]
		public double? Sponsorcommision { get; set; }
		[Required(ErrorMessage = "Please Enter Commission")]
		public double? Sfinalcommission { get; set; }
		[Required(ErrorMessage = "Please Enter Sponsor Bank")]
		public string? Sbankname { get; set; }
		[Required(ErrorMessage = "Please Enter Sponsor Branch")]
		public string? Sbranchname { get; set; }
		[Required(ErrorMessage = "Please Enter Sponsor IFSC")]
		public string? Sifsc { get; set; }
		[Required(ErrorMessage = "Please Enter Sponsor Account No.")]
		public string SAccountno { get; set; }
		public string? Scheque { get; set; }

		public DateTime? Schequedate { get; set; }

		public string? Supi { get; set; }


		[Range(1, 100000, ErrorMessage = "Please Select Customer")]
		public int? Customerid { get; set; }
		public string? CustomerName { get; set; }
		public string? CMobile { get; set; }
		public string? CWhataApp { get; set; }
		public string? CAddress { get; set; }

		public int? Projectid { get; set; }
		[Range(1, 100, ErrorMessage = "Please Select Project")]
		public string? ProjectName {  get; set; }

		[Range(1, 100, ErrorMessage = "Please Select Property Type")]
		public int? Propertyid { get; set; }

		public string Propertyname { get; set; }
		[Range(1, 100, ErrorMessage = "Please Select Block")]
		public int? Blockid { get; set; }
		public string Blockname { get; set; }
		//[Required (ErrorMessage = "Please Select Plot")]
		public string? Plotno { get; set; }

		public string? Plotsize { get; set; }
		[Required(ErrorMessage = "Please Enter Direction")]
		public string? Direction { get; set; }

		public string? Chauhaddi { get; set; }

		public string? Aarajino { get; set; }
		public string? PlotSize { get; set; }
		public string? Propertydetails { get; set;}
		[Required(ErrorMessage = "Please Enter Cutomer Bank")]
		public string? Bankname { get; set; }
		[Required(ErrorMessage = "Please Enter Cutomer Branch")]
		public string? Branchname { get; set; }
		[Required(ErrorMessage = "Please Enter Cutomer IFSC")]
		public string? Ifsc { get; set; }
		[Required(ErrorMessage = "Please Enter Cutomer Account")]
		public string Accountno { get; set; }

		public string? Cheque { get; set; }

		public DateTime? Chequedate { get; set; }

		public string? Upi { get; set; }
		[Required(ErrorMessage = "Please Enter Final Amount")]
		public double? Finalamount { get; set; }
		[Required(ErrorMessage = "Please Enter Due Amount")]
		public double? Dueamount { get; set; }
		[Required(ErrorMessage = "Please Enter Received Amount")]
		public double? Advanceamoutn { get; set; }
		public double ? profit {  get; set; }



		public string? Loancustomerfull { get; set; }
		public IFormFile? imgLoancustomerfull {  get; set; }

		public string? Loansalaryslip { get; set; }
		public IFormFile? imgLoansalaryslip { get; set; }
		 

		public string? Customerfeedback { get; set; }

		public DateTime? Createddate { get; set; }

		public DateTime? Editeddate { get; set; }
		public List<SaleModel> SaleModelList { get; set;}
		public List<SelectListItem>SponsorList { get; set; }
		public List<SelectListItem>CustomerList { get; set; }
		public List<SelectListItem>ProjectList {  get; set; }
		public List<SelectListItem>ProperyTypeList { get; set; }	
		public List<SelectListItem> BlockList { get; set; }
		public List<SelectListItem> PlotList { get; set; }	
	}
}

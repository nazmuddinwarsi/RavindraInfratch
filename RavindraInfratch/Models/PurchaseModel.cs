using Microsoft.AspNetCore.Mvc.Rendering;

namespace RavindraInfratch.Models
{
	public class PurchaseModel
	{
		public int Id { get; set; }

		public int? Sponsorid { get; set; }
		public string SponsorName { get; set; }

		public int? Accountid { get; set; }
		public string AccountName { get; set; }
		public string Mobile { get; set; }
		public string WhatsApp { get; set; }
		public string Address2 { get; set; }

		public string? Deed { get; set; }

		public string? Bankname { get; set; }

		public string? Branchname { get; set; }

		public string? Ifsc { get; set; }
		public string? AccountNo {  get; set; }	

		public string? Cheque { get; set; }

		public DateTime? Chequedate { get; set; }

		public string? Upi { get; set; }

		public string? Banknoc { get; set; }
		public IFormFile? imgBanknoc {  get; set; }
		public string? Oldagreement { get; set; }
		public IFormFile? imgOldagreement { get; set; }
		public string? Shareholder { get; set; }

		

		public string? Agreementdeadline { get; set; }

		public string? Aarajino { get; set; }

		public double? Area { get; set; }

		public double Finalamount { get; set; }

		public double? Dueamount { get; set; }

		public double? Advanceamoutn { get; set; }
		public int? FromAccountId { get; set; }

		public int? Advocateid { get; set; }
		public string? AdvocateName { get; set; }
		public string? Stamp { get; set; }
		public IFormFile? imgStamp { get; set; }

		public string? Rasid { get; set; }
		public IFormFile? imgRasid { get; set; }

		public double? Courtfee { get; set; }
		public double? AdvocateFee { get; set; }

		public double? OtherFee { get; set; }

		public string? Lekhpalname { get; set; }

		public string? Lekhpalmobile { get; set; }

		public string? Inspection1356 { get; set; }
		public IFormFile? imgInspection1356 { get; set; }

		public string? Inspection1291 { get; set; }
		public IFormFile? imgInspection1291 { get; set; }

		public string? Sala12 { get; set; }
		public IFormFile? imgSala12 { get; set; }

		public string? Najrinaksha { get; set; }
		public IFormFile? imgNajrinaksha { get; set; }

		public string? Khasra { get; set; }
		public IFormFile? imgKhasra { get; set; }
		public string? Khatauni { get; set; }
		public IFormFile? imgKhatauni { get; set; }

		public DateTime? Createddate { get; set; }

		public DateTime? Editeddate { get; set; }

		public int? Process { get; set; }
	 
		public List<SelectListItem> SponsorList { get; set; }
		public List<SelectListItem> SellerList { get; set; }
		public  PhotoModel PhotoModel { get; set; }
		public List<PhotoModel> PhotoModelList { get; set; }
	}
}

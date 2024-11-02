using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
namespace RavindraInfratch.Models
{
	public class PhotoModel
	{
		public int Id { get; set; }

		public string? Ttype { get; set; }

		public string? Tpath { get; set; }
 
		public IFormFile? imgPhoto { get; set; }
		public IFormFile? imgVideo { get; set; }
		public int? PurchaseId  	{get;set;}
		public List<PhotoModel> PhotosList { get; set; }
		
		


	}
}

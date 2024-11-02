using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RavindraInfratch.Models
{
	public class PlotModel
	{
		public int Id { get; set; }

		public int? Projectid { get; set; }
		public string? ProjectName { get; set; }

		public int? Propertyid { get; set; }
		public string? Propertyname { get; set; }


		public int? Blockid { get; set; }
		public string? Blockname { get; set; }
		[Required(ErrorMessage ="Please enter plot quantity")]
		[Range(1, 100, ErrorMessage = "Plot quantity must be between 1 to 100")]
		public int? Plots { get; set; }
		public string? PlotSize { get; set; }	
		public List<PlotModel> PlotModelList { get; set; }
		public List<SelectListItem> ProjectList { get; set; }
		public List<SelectListItem> PropertyList { get; set; }
		public List<SelectListItem> BlockListSelect { get; set; }
	}
}

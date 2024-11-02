using System.ComponentModel.DataAnnotations;

namespace RavindraInfratch.Models
{
	public class PropertyTypeModel
	{
		public int Id { get; set; }
		[Required (ErrorMessage ="Propety Type cannot be null")]
		public string? tType { get; set; }
		public List<PropertyTypeModel> PropertyTypeList { get; set; }
	}
}

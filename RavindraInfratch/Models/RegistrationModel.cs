using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace RavindraInfratch.Models
{
	public class RegistrationModel
	{
		public List<SelectListItem> RegistrationList { get; set; }
	 
		public RegistrationList Reg {  get; set; }
		public List<SelectListItem> StateListModel { get; set; }
		public StateList State { get; set; }
	}
}

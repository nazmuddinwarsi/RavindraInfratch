 
using System.ComponentModel.DataAnnotations;

namespace RavindraInfratch.Models
{
	public class ExpenseTypeList
	{
		public int Id { get; set; }

		[Required(ErrorMessage="Expense Type is must !")]
		 public string? FldName { get; set; }

		public string ? tType {  get; set; }
		public short? CreatedBy { get; set; }

		public DateTime? CreatedDate { get; set; }

		public short? EditedBy { get; set; }

		public DateTime? EditedDate { get; set; }
	}
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RavindraInfratch.Models
{
	 
	public class StatementModel
	{


		public string? IDate { get; set; }

		public string? PartyName { get; set; }
		 
		public decimal Amt { get; set; }

		public decimal Commission { get; set; }

		public decimal PaymentRecAmt { get; set; }

		public string? CommissionType { get; set; }

		public DateTime? ODate { get; set; }
	}
}

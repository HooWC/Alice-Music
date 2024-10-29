using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alice_DomainModelEntity.Models
{
	public class Transaction
	{
		[Key]
		public int Id { get; set; }
		public DateTime PaidTime { get; set; }
		public EnumTransation TransactionStatus { get; set; }
		public string CartIDList { get; set; }
		public int? UserID { get; set; }
	}

	public enum EnumTransation
	{
		Pending, Paid
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alice_DomainModelEntity.Models
{
	public class Cart
	{
		[Key]
		public int CartID { get; set; }
		public int? UserID { get; set; }
		public int? MusicID { get; set; }
		public decimal? MusicPrice { get; set; }
		public bool IsPaid { get; set; }
		public bool IsSelected { get; set; }
	}
}

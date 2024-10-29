using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alice_DomainModelEntity.Models
{
	public class SingerStore
	{
		[Key]
		public int SingerStoreID { get; set; }
		public int SingerID { get; set; }
		public int UserID { get; set; }
	}
}

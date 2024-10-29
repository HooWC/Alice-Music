using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alice_DomainModelEntity.Models
{
	public class VideoStore
	{
		[Key]
		public int VideoStoreID { get; set; }
		public int? VideoID { get; set; }
		public int? UserID { get; set; }
	}
}

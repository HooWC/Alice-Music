using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alice_DomainModelEntity.Models
{
	public class Video
	{
		[Key]
		public int VideoId { get; set; }
		public int? MusicID { get; set; }
		public string? Link { get; set; }
	}
}

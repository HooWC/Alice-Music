using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alice_DomainModelEntity.Models
{
	public class Music
	{
		[Key]
		public int MusicId { get; set; }
		public int? SingerID { get; set; }
		public string? SongName { get; set; }
		public string? SongType { get; set; }
		public string? SongImg { get; set; }
		public EnumMusicVIP SongVIP { get; set; }
		public decimal? SongPrice { get; set; }
	}

	public enum EnumMusicVIP
	{
		Free, Vip
	}
}

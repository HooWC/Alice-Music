using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alice_DomainModelEntity.Models
{
	public class Singer
	{
		[Key]
		public int SingerID { get; set; }
		public string? SingerName { get; set; }
		public string? SingerImage { get; set; }
		public string? SingerInfo { get; set; }
		public EnumTeam SingerType { get; set; }
		public EnumType Type { get; set; }
		public DateTime? DebutTime { get; set; }
	}

	public enum EnumTeam
	{
		Orchestra, Individual
	}

	public enum EnumType
	{
		Chinese, Japanese, English, Other
	}
}

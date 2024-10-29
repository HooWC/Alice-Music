using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alice_DomainModelEntity.Models
{
	public class User
	{
		[Key]
		public int UserID { get; set; }
		public string? UserName { get; set; }
		public string? UserGmail { get; set; }
		public string? Password { get; set; }
		public EnumGender Gender { get; set; }
		public string? Address { get; set; }
		public DateTime CreateDate { get; set; }
		public string? Head { get; set; }
	}

	public enum EnumGender
	{
		Male, Female, Other
	}
}

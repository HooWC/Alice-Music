using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alice_DomainModelEntity.Models
{
	public class Comment
	{
		[Key]
		public int CommentID { get; set; }
		public int? Movie_Id { get; set; }
		public int? User_Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public string? CommentWord { get; set; }
	}
}

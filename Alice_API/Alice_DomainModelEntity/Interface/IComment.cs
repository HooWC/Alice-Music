using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alice_DomainModelEntity.Models;

namespace Alice_DomainModelEntity.Interface
{
	public interface IComment
	{
		Task<IEnumerable<Comment>> GetAllComment();
		Task<Comment?> GetComment(int? id);

		void CreateComment(Comment comment);
		void UpdateComment(Comment comment);
		void DeleteCommentAsync(int? id);
		void Save();
	}
}

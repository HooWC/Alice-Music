using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alice_DomainModelEntity.Interface;
using Alice_DomainModelEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace Alice_Infrastructure.Repository
{
	public class CommentRepository : IComment
	{
		AppDbContext db = new AppDbContext();

		public void CreateComment(Comment comment)
		{
			db.Comments.Add(comment);
			Save();
		}

		public async void DeleteCommentAsync(int? id)
		{
			var comment = await db.Comments.FindAsync(id);
			db.Comments.Remove(comment);
			Save();
		}

		public async Task<IEnumerable<Comment>> GetAllComment()
		{
			return await db.Comments.ToListAsync();
		}

		public async Task<Comment?> GetComment(int? id)
		{
			return await db.Comments.FindAsync(id);
		}

		public void Save()
		{
			db.SaveChangesAsync();
		}

		public void UpdateComment(Comment comment)
		{
			db.Comments.Update(comment);
			Save();
		}
	}
}

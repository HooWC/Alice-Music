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
	public class UserRepository : IUser
	{
		AppDbContext db = new AppDbContext();

		public void CreateUser(User user)
		{
			db.Users.Add(user);
			Save();
		}

		public async void DeleteUserAsync(int? id)
		{
			var u = await db.Users.FindAsync(id);
			db.Users.Remove(u);
			Save();
		}

		public async Task<IEnumerable<User>> GetAllUser()
		{
			return await db.Users.ToListAsync();
		}

		public async Task<User?> GetUser(int? id)
		{
			return await db.Users.FindAsync(id);
		}

		public void Save()
		{
			db.SaveChangesAsync();
		}

		public void UpdateUser(User user)
		{
			db.Users.Update(user);
			Save();
		}



	}
}

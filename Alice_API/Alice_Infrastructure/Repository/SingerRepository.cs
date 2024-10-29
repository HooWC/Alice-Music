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
	public class SingerRepository : ISinger
	{
		AppDbContext db = new AppDbContext();

		public void CreateSinger(Singer s)
		{
			db.Singers.Add(s);
			Save();
		}

		public async void DeleteSingerAsync(int? id)
		{
			var singer = await db.Singers.FindAsync(id);
			db.Singers.Remove(singer);
			Save();
		}

		public async Task<IEnumerable<Singer>> GetAllSinger()
		{
			return await db.Singers.ToListAsync();
		}

		public async Task<Singer?> GetSinger(int? id)
		{
			return await db.Singers.FindAsync(id);
		}

		public void Save()
		{
			db.SaveChangesAsync();
		}

		public void UpdateSinger(Singer s)
		{
			db.Singers.Update(s);
			Save();
		}
	}
}

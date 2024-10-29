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
	public class SingerStoreRepository : ISingerStore
	{
		AppDbContext db = new AppDbContext();

		public void CreateSingerStore(SingerStore singerStore)
		{
			db.SingerStores.Add(singerStore);
			Save();
		}

		public async void DeleteSingerStoreAsync(int? id)
		{
			var singerStore = await db.SingerStores.FindAsync(id);
			db.SingerStores.Remove(singerStore);
			Save();
		}

		public async Task<IEnumerable<SingerStore>> GetAllSingerStore()
		{
			return await db.SingerStores.ToListAsync();
		}

		public async Task<SingerStore?> GetSingerStore(int? id)
		{
			return await db.SingerStores.FindAsync(id);
		}

		public void Save()
		{
			db.SaveChangesAsync();
		}

		public void UpdateSingerStore(SingerStore singerStore)
		{
			db.SingerStores.Update(singerStore);
			Save();
		}
	}
}

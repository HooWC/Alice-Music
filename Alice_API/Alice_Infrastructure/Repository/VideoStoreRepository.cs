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
	public class VideoStoreRepository : IVideoStore
	{
		AppDbContext db = new AppDbContext();

		public void CreateVideoStore(VideoStore videoStore)
		{
			db.VideoStores.Add(videoStore);
			Save();
		}

		public async void DeleteVideoStoreAsync(int? id)
		{
			var videoStore = await db.VideoStores.FindAsync(id);
			db.VideoStores.Remove(videoStore);
			Save();
		}

		public async Task<IEnumerable<VideoStore>> GetAllVideoStore()
		{
			return await db.VideoStores.ToListAsync();
		}

		public async Task<VideoStore?> GetVideoStore(int? id)
		{
			return await db.VideoStores.FindAsync(id);
		}

		public void Save()
		{
			db.SaveChangesAsync();
		}

		public void UpdateVideoStore(VideoStore videoStore)
		{
			db.VideoStores.Update(videoStore);
			Save();
		}
	}
}

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
	public class VideoRepository : IVideo
	{
		AppDbContext db = new AppDbContext();

		public void CreateVideo(Video video)
		{
			db.Videos.Add(video);
			Save();
		}

		public async void DeleteVideoAsync(int? id)
		{
			var video = await db.Videos.FindAsync(id);
			db.Videos.Remove(video);
			Save();
		}

		public async Task<IEnumerable<Video>> GetAllVideo()
		{
			return await db.Videos.ToListAsync();
		}

		public async Task<Video?> GetVideo(int? id)
		{
			return await db.Videos.FindAsync(id);
		}

		public void Save()
		{
			db.SaveChangesAsync();
		}

		public void UpdateVideo(Video video)
		{
			db.Videos.Update(video);
			Save();
		}
	}
}

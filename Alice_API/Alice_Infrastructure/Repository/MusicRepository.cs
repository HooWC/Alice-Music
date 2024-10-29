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
	public class MusicRepository : IMusic
	{
		AppDbContext db = new AppDbContext();

		public void CreateMusic(Music music)
		{
			db.Musics.Add(music);
			Save();
		}

		public async void DeleteMusicAsync(int? id)
		{
			var music = await db.Musics.FindAsync(id);
			db.Musics.Remove(music);
			Save();
		}

		public async Task<IEnumerable<Music>> GetAllMusic()
		{
			return await db.Musics.ToListAsync();
		}

		public async Task<Music?> GetMusic(int? id)
		{
			return await db.Musics.FindAsync(id);
		}

		public void Save()
		{
			db.SaveChangesAsync();
		}

		public void UpdateMusic(Music music)
		{
			db.Musics.Update(music);
			Save();
		}
	}
}

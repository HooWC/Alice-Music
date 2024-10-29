using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alice_DomainModelEntity.Models;

namespace Alice_DomainModelEntity.Interface
{
	public interface IMusic
	{
		Task<IEnumerable<Music>> GetAllMusic();
		Task<Music?> GetMusic(int? id);

		void CreateMusic(Music music);
		void UpdateMusic(Music music);
		void DeleteMusicAsync(int? id);
		void Save();
	}
}

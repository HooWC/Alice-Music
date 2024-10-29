using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alice_DomainModelEntity.Models;

namespace Alice_DomainModelEntity.Interface
{
	public interface IVideoStore
	{
		Task<IEnumerable<VideoStore>> GetAllVideoStore();
		Task<VideoStore?> GetVideoStore(int? id);

		void CreateVideoStore(VideoStore videoStore);
		void UpdateVideoStore(VideoStore videoStore);
		void DeleteVideoStoreAsync(int? id);
		void Save();
	}
}

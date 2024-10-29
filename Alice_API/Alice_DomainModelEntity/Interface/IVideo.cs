using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alice_DomainModelEntity.Models;

namespace Alice_DomainModelEntity.Interface
{
	public interface IVideo
	{
		Task<IEnumerable<Video>> GetAllVideo();
		Task<Video?> GetVideo(int? id);

		void CreateVideo(Video video);
		void UpdateVideo(Video video);
		void DeleteVideoAsync(int? id);
		void Save();
	}
}

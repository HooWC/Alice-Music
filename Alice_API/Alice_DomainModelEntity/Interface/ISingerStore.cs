using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alice_DomainModelEntity.Models;

namespace Alice_DomainModelEntity.Interface
{
	public interface ISingerStore
	{
		Task<IEnumerable<SingerStore>> GetAllSingerStore();
		Task<SingerStore?> GetSingerStore(int? id);

		void CreateSingerStore(SingerStore singerStore);
		void UpdateSingerStore(SingerStore singerStore);
		void DeleteSingerStoreAsync(int? id);
		void Save();
	}
}

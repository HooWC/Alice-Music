using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alice_DomainModelEntity.Models;

namespace Alice_DomainModelEntity.Interface
{
	public interface ISinger
	{
		Task<IEnumerable<Singer>> GetAllSinger();
		Task<Singer?> GetSinger(int? id);

		void CreateSinger(Singer s);
		void UpdateSinger(Singer s);
		void DeleteSingerAsync(int? id);
		void Save();
	}
}

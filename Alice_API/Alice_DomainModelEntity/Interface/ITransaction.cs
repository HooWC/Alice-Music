using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alice_DomainModelEntity.Models;

namespace Alice_DomainModelEntity.Interface
{
	public interface ITransaction
	{
		Task<IEnumerable<Transaction>> GetAllTransaction();
		Task<Transaction?> GetTransaction(int? id);

		void CreateTransaction(Transaction tr);
		void UpdateTransaction(Transaction tr);
		void DeleteTransactionAsync(int? id);
		void Save();
	}
}

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
	public class TransactionRepository : ITransaction
	{
		AppDbContext db = new AppDbContext();

		public void CreateTransaction(Transaction tr)
		{
			db.Transactions.Add(tr);
			Save();
		}

		public async void DeleteTransactionAsync(int? id)
		{
			var tr = await db.Transactions.FindAsync(id);
			db.Transactions.Remove(tr);
			Save();
		}

		public async Task<IEnumerable<Transaction>> GetAllTransaction()
		{
			return await db.Transactions.ToListAsync();
		}

		public async Task<Transaction?> GetTransaction(int? id)
		{
			return await db.Transactions.FindAsync(id);
		}

		public void Save()
		{
			db.SaveChangesAsync();
		}

		public void UpdateTransaction(Transaction tr)
		{
			db.Transactions.Update(tr);
			Save();
		}
	}
}

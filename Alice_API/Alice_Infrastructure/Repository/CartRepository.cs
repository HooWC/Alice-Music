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
	public class CartRepository : ICart
	{
		AppDbContext db = new AppDbContext();

		public void CreateCart(Cart cart)
		{
			db.Carts.Add(cart);
			Save();
		}

		public async void DeleteCart(int? id)
		{
			var cart = await db.Carts.FindAsync(id);
			db.Carts.Remove(cart);
			Save();
		}

		public async Task<IEnumerable<Cart>> GetAllCart()
		{
			return await db.Carts.ToListAsync();
		}

		public async Task<Cart?> GetCart(int? id)
		{
			return await db.Carts.FindAsync(id);
		}

		public void Save()
		{
			db.SaveChangesAsync();
		}

		public void UpdateCart(Cart cart)
		{
			db.Carts.Update(cart);
			Save();
		}
	}
}

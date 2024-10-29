using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alice_DomainModelEntity.Models;

namespace Alice_DomainModelEntity.Interface
{
	public interface ICart
	{
		Task<IEnumerable<Cart>> GetAllCart();
		Task<Cart?> GetCart(int? id);

		void CreateCart(Cart cart);
		void UpdateCart(Cart cart);
		void DeleteCart(int? id);
		void Save();
	}
}

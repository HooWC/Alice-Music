using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alice_DomainModelEntity.Models;

namespace Alice_DomainModelEntity.Interface
{
	public interface IUser
	{
		Task<IEnumerable<User>> GetAllUser();
		Task<User?> GetUser(int? id);

		void CreateUser(User user);
		void UpdateUser(User user);
		void DeleteUserAsync(int? id);
		void Save();
	}
}

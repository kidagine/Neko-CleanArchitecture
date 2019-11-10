using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.DomainService
{
	public interface IUserRepository
	{
		User Create(User user);
		User Update(User user);
		User Delete(int id);
		User ReadById(int id);
		IEnumerable<User> ReadAll();
	}
}

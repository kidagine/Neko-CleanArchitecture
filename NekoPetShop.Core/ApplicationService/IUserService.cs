using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.ApplicationService
{
	public interface IUserService
	{
		User Create(User user);
		User Update(User user);
		User Delete(int id);
		User ReadById(int id);
		List<User> ReadAll();
		User ValidateUser(LoginInputModel loginInputModel);
	}
}

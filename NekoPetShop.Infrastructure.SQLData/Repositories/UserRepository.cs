using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NekoPetShop.Core.DomainService;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Infrastructure.SQLData.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly NekoPetShopContext _context;


		public UserRepository(NekoPetShopContext context)
		{
			_context = context;
		}

		public User Create(User user)
		{
			_context.Attach(user).State = EntityState.Added;
			_context.SaveChanges();
			return user;
		}

		public User Update(User user)
		{
			_context.Attach(user).State = EntityState.Modified;
			_context.SaveChanges();
			return user;
		}

		public User Delete(int id)
		{
			User user = ReadById(id);
			_context.Attach(user).State = EntityState.Deleted;
			_context.SaveChanges();
			return user;
		}

		public User ReadById(int id)
		{
			return _context.Users.AsNoTracking().FirstOrDefault(u => u.Id == id);
		}

		public IEnumerable<User> ReadAll()
		{
			return _context.Users.AsNoTracking();
		}
	}
}

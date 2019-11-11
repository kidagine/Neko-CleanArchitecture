using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.Helpers;
using NekoPetShop.Core.DomainService;

namespace NekoPetShop.Core.ApplicationService.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IAuthenticationHelper _authenticationHelper;


		public UserService(IUserRepository userRepository, IAuthenticationHelper authenticationHelper)
		{
			_userRepository = userRepository;
			_authenticationHelper = authenticationHelper;
		}

		public User Create(User user)
		{
			if (user.Id != default)
			{
				throw new NotSupportedException($"The user id should not be specified");
			}
			if (string.IsNullOrEmpty(user.Username))
			{
				throw new InvalidDataException("You need to specify the user's name.");
			}
			return _userRepository.Create(user);
		}

		public User Update(User user)
		{
			return _userRepository.Update(user);
		}

		public User Delete(int id)
		{
			return _userRepository.Delete(id);
		}

		public User ReadById(int id)
		{
			return _userRepository.ReadById(id);
		}

		public List<User> ReadAll()
		{
			return _userRepository.ReadAll().ToList();
		}

		public User ValidateUser(LoginInputModel loginInputModel)
		{
			User user = _userRepository.ReadAll().FirstOrDefault(u => u.Username == loginInputModel.Username);
			if (user == null)
			{
				throw new NullReferenceException("Invalid User");
			}
			if (!_authenticationHelper.VerifyPasswordHash(loginInputModel.Password, user.PasswordHash, user.PasswordSalt))
			{
				throw new ArgumentException("Invalid Password");
			}
			return user;
		}
	}
}

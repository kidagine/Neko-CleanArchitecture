using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.Helpers
{
	public interface IAuthenticationHelper
	{
		void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
		bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
		string GenerateToken(User user);
	}
}

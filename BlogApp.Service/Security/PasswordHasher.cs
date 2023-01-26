using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Security;

public static class PasswordHasher
{
	public static (string salt, string Hash) Hasher(string password)
	{
		var salt =  Guid.NewGuid().ToString();
		string passwordHash = BCrypt.Net.BCrypt.HashPassword(salt+password);

		return(salt,passwordHash);	
	}
	public static bool Verify(string password, string salt, string hash)
	{
		return BCrypt.Net.BCrypt.Verify(salt + password, hash);
	}

	public static string ChangePassword(string password, string salt)
	{
		return BCrypt.Net.BCrypt.HashPassword(salt + password);
	}
}

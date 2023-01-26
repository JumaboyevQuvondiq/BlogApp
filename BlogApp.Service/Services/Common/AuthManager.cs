using BlogApp.Domain.Entities.Users;
using BlogApp.Service.Interfaces;
using BlogApp.Service.Interfaces.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services.Common
{
	public class AuthManager : IAuthManager
	{
		private readonly IConfiguration _config;

		public AuthManager(IConfiguration configuration)
		{
			_config = configuration.GetSection("Jwt");
		}

		public string GeneratedToken(User user)
		{
			var claims = new[]
			{
				new Claim("Id", user.Id.ToString()),
				new Claim("Name", user.FullName.ToString()),
				new Claim("ImagePath",(user.ImagePath is null)?"":user.ImagePath),
				new Claim(ClaimTypes.Email, user.Email),
			};
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

			var tokenDescription = new JwtSecurityToken(_config["Issuer"], _config["Audience"], claims,
				expires: DateTime.Now.AddMinutes(double.Parse(_config["Lifetime"])),
				signingCredentials: credentials);
			return new JwtSecurityTokenHandler().WriteToken(tokenDescription);
		}
	}
}

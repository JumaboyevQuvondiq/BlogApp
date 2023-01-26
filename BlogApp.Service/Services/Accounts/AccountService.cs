using BlogApp.DataAccess.Interfaces;
using BlogApp.Domain.Entities.Users;
using BlogApp.Service.Dtos.Accounts;
using BlogApp.Service.Interfaces.Accounts;
using BlogApp.Service.Interfaces.Common;
using BlogApp.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services.Accounts
{
	public class AccountService : IAccountService
	{
		private readonly IUnitOfWork _repository;
		private readonly IAuthManager _authManager;

		public AccountService(IUnitOfWork unitOfWork, IAuthManager authManager) {
			_repository = unitOfWork;
			_authManager = authManager;	
		}	
		public async Task<string> LoginAsync(AccountLoginDto accountLoginDto)
		{
		  var user = await _repository.Users.FirstOrDefault(x => x.Email == accountLoginDto.Email);
			if (user is  null) { throw new Exception("Bunday foydalanuvchi yo`q"); }
			var res = PasswordHasher.Verify(accountLoginDto.Password, user.Salt, user.Password);
			if(!res) { throw new Exception("parol xato"); }

			return _authManager.GeneratedToken(user);
		}

		public async Task<bool> RegisterAsync(AccountRegisterDto accountRegisterDto)
		{
			var user = await _repository.Users.FirstOrDefault(x=> x.Email== accountRegisterDto.Email);	
			if (user is not null) { throw new Exception("Bunday foydalanuvchi bor"); }
			user = (User)accountRegisterDto;
			var passwordHash = PasswordHasher.Hasher(accountRegisterDto.Password);
			user.Password = passwordHash.Hash;
			user.Salt = passwordHash.salt;
			_repository.Users.Add(user);
			var res = await _repository.SaveChangesAsync();	
			return res;
		}
	}
}

using BlogApp.Service.Dtos.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Interfaces.Accounts
{
	public interface IAccountService
	{
		public Task<string> LoginAsync(AccountLoginDto accountLoginDto);
		public Task<bool> RegisterAsync(AccountRegisterDto accountRegisterDto);
	}
}

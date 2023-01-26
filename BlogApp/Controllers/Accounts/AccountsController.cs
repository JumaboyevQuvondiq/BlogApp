using BlogApp.Service.Dtos.Accounts;
using BlogApp.Service.Interfaces.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers.Accounts
{
	[Route("accounts")]

	public class AccountsController : Controller
	{
		private readonly IAccountService _accountService;

		public AccountsController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpGet("login")]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost("login")]
		public async Task<IActionResult> LoginAsync(AccountLoginDto accountLoginDto)
		{
			if(ModelState.IsValid)
			{
				var res = await _accountService.LoginAsync(accountLoginDto);
				if (res is null) return Login();
				HttpContext.Response.Cookies.Append("X-Access-Token", res, new CookieOptions()
				{
					HttpOnly = true,
					SameSite = SameSiteMode.Strict
				});
				return RedirectToAction("create", "blogs", new { area = "" });
			}
			return Login();
		}
		[HttpGet("register")]
		public IActionResult Register() 
		{
			return View();	
		}
		[HttpPost("register")]

		public async Task<IActionResult> RegisterAsync(AccountRegisterDto accountRegisterDto)
		{
			if(ModelState.IsValid) 
			{
				var res = await _accountService.RegisterAsync(accountRegisterDto);
				if (res)
					return RedirectToAction("login", "accounts", new { area = "" });
				return Register();
			}
			return Register();

		}
	}

}

using BlogApp.Service.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Dtos.Accounts
{
	public class AccountLoginDto
	{
		[Required,EmailAddress]
		public string Email { get; set; } = string.Empty;
		[Required, StrongPassword]
		public string Password { get; set; } = string.Empty;


	}
}

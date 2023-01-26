using BlogApp.Domain.Common;
using BlogApp.Domain.Entities.Users;
using BlogApp.Service.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Dtos.Accounts
{
	public class AccountRegisterDto:BaseEntity
	{
		[Required, MaxLength(70), MinLength(2)]
		public string FullName { get; set; } = string.Empty;
		[Required,EmailAddress]
		public string Email { get; set; }	= string.Empty;
		[Required,StrongPassword]
		public string Password { get; set; } = string.Empty;

		public static implicit operator User(AccountRegisterDto accountRegisterDto)
		{
			return new User()
			{
				Id = 1,
				FullName = accountRegisterDto.FullName,
				Email = accountRegisterDto.Email,
				CreatedAt = DateTime.UtcNow,
				UpdatedAt = DateTime.UtcNow,

			};
		}
	}
}

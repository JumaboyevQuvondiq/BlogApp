using BlogApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Entities.Users
{
	public class User :Auditable
	{
		public string FullName { get; set; }= string.Empty;
		public string Email { get; set; } = string.Empty;	
		public string Password { get; set; } = string.Empty;
		public string Salt { get; set; }= string.Empty;	
		public string? ImagePath { get; set; } = string.Empty;
		
	}
}

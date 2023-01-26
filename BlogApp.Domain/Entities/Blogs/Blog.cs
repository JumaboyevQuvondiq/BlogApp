using BlogApp.Domain.Common;
using BlogApp.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Entities.Blogs
{
	public class Blog:Auditable
	{
		public long UserId { get; set; }	
		public virtual User? User { get; set; }	
		public string Title { get; set; } = string.Empty;	
		public string Content { get; set; } =string.Empty;
		public string ImagePath { get; set; } = string.Empty;	
		public bool IsUpdated { get; set; }	= false;
	}
}

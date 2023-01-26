using BlogApp.DataAccess.DbContexts;
using BlogApp.DataAccess.Interfaces.Blogs;
using BlogApp.DataAccess.Interfaces.Users;
using BlogApp.Domain.Entities.Blogs;
using BlogApp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccess.Interfaces
{
	public interface IUnitOfWork
	{
		public IUserRepository Users { get; }
		public IBlogRepository Blogs { get; }	
		public Task<bool> SaveChangesAsync();
	}
}

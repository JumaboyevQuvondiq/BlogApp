using BlogApp.DataAccess.DbContexts;
using BlogApp.DataAccess.Interfaces;
using BlogApp.DataAccess.Interfaces.Blogs;
using BlogApp.DataAccess.Interfaces.Users;
using BlogApp.DataAccess.Repositories.Blogs;
using BlogApp.DataAccess.Repositories.Users;
using BlogApp.Domain.Entities.Blogs;
using BlogApp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccess.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _repository;

		
		public IUserRepository Users { get; } 

		public IBlogRepository Blogs { get; }

		public UnitOfWork(AppDbContext appDbContext)
		{
			_repository = appDbContext;
			Users = new UserRepository(appDbContext);
			Blogs = new BlogRepository(appDbContext);


		}

		public async Task<bool> SaveChangesAsync()
		{
		  var res= await	_repository.SaveChangesAsync();
			return res > 0;
		}

	}
}

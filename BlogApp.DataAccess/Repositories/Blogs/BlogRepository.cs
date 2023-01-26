using BlogApp.DataAccess.DbContexts;
using BlogApp.DataAccess.Interfaces.Blogs;
using BlogApp.Domain.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccess.Repositories.Blogs
{
	public class BlogRepository : GenericRepository<Blog>, IBlogRepository
	{
		public BlogRepository(AppDbContext appDbContext) : base(appDbContext)
		{
		}
	}
}

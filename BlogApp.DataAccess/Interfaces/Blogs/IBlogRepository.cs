using BlogApp.DataAccess.Repositories;
using BlogApp.Domain.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccess.Interfaces.Blogs
{
	public interface IBlogRepository  : IGenericRepository<Blog>
	{
	}
}

using BlogApp.Domain.Entities.Blogs;
using BlogApp.Service.Dtos.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Interfaces.Blogs
{
	public interface IBlogService
	{
		public Task<IEnumerable<Blog>> GetAllAsync();
		public Task<Blog> BlogGetByIdAsync(long id);
		public Task<bool> CreateAsync(BlogCreateDto blog);
		public Task<bool> UpdateAsync(long Id, Blog blog);
		public Task DeleteAsync(long Id);	
	}
}

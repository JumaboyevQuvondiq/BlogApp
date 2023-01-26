using BlogApp.DataAccess.Interfaces;
using BlogApp.Domain.Entities.Blogs;
using BlogApp.Service.Dtos.Blogs;
using BlogApp.Service.Interfaces;
using BlogApp.Service.Interfaces.Blogs;
using BlogApp.Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services.Blogs
{
	public class BlogService : IBlogService
	{
        private readonly IUnitOfWork _repository;
        private readonly IFileService _fileService;
        private readonly IIdentityService _identityService;

        public BlogService(IUnitOfWork unitOfWork, IIdentityService identityService,IFileService fileService)
		{
			_repository = unitOfWork;
			_fileService = fileService;
			_identityService = identityService;
		}
		public async Task<Blog> BlogGetByIdAsync(long id)
		{
		 var blog= await _repository.Blogs.GetById(id);
			return blog;
		}

		public async Task<bool> CreateAsync(BlogCreateDto blog)
		{
			Blog blog1 = new Blog()
			{
				Title= blog.Title,	
				Content = blog.Context,
				UserId =_identityService.Id!.Value,
				CreatedAt= DateTime.UtcNow,
				UpdatedAt= DateTime.UtcNow,	
				
			};
			blog1.ImagePath = await _fileService.SaveImageAsync(blog.Image);
			
			_repository.Blogs.Add(blog1);	
			return await _repository.SaveChangesAsync();	
			
		}

		public Task DeleteAsync(long Id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Blog>> GetAllAsync()
		{
		  return await	_repository.Blogs.GetAllAsync();
		}

		public Task<bool> UpdateAsync(long Id, Blog blog)
		{
			throw new NotImplementedException();
		}
	}
}

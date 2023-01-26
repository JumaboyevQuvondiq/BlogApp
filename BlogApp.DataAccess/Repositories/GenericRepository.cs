using BlogApp.DataAccess.DbContexts;
using BlogApp.DataAccess.Interfaces;
using BlogApp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccess.Repositories
{
	public class GenericRepository<T> : BaseRepository<T>, IGenericRepository<T> where T : BaseEntity
	{
		public GenericRepository(AppDbContext appDbContext) : base(appDbContext)
		{
		}

		public async Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression) => await _dbSet.FirstOrDefaultAsync(expression);
		
	}
}

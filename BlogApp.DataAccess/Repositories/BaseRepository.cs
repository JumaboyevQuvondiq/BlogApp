using BlogApp.DataAccess.DbContexts;
using BlogApp.DataAccess.Interfaces;
using BlogApp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccess.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
	{
		private AppDbContext _dbContext;
		public readonly DbSet<T> _dbSet;

		public BaseRepository(AppDbContext appDbContext)
		{
			_dbContext = appDbContext;
			_dbSet = appDbContext.Set<T>();
		}
		public void Add(T entity) =>_dbSet.Add(entity);
		

		public void Delete(T entity)=>_dbSet.Remove(entity);
		

		public async Task<IEnumerable<T>> GetAllAsync()
		{
		  return _dbSet;
		}

		public async Task<T> GetById(long id)
		{
		 return	_dbSet.FirstOrDefault(x => x.Id == id);	
		}

		public void Update(T entity)=> _dbSet.Update(entity);
	}
}

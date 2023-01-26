using BlogApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccess.Interfaces
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		public  Task<T> GetById(long id);
		public Task<IEnumerable<T>> GetAllAsync();
		public void Add(T entity);
		public void Update(T entity);
		public void Delete(T entity);
	}
}

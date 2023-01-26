using BlogApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccess.Interfaces
{
	public interface IGenericRepository<T> :IBaseRepository<T> where T : BaseEntity
	{
		public  Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression);
	}
}

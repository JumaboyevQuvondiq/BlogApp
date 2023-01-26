using BlogApp.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccess.Interfaces.Users
{
	public interface IUserRepository : IGenericRepository<User>
	{
	}
}

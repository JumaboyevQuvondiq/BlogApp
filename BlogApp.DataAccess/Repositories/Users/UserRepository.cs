using BlogApp.DataAccess.DbContexts;
using BlogApp.DataAccess.Interfaces.Users;
using BlogApp.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccess.Repositories.Users
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		public UserRepository(AppDbContext appDbContext) : base(appDbContext)
		{
		}
	}
}

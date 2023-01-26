using BlogApp.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Interfaces.Common
{
    public interface IAuthManager
    {
        public string GeneratedToken(User user);
    }
}

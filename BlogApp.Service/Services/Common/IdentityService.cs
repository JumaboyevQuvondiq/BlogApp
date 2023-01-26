using BlogApp.Service.Interfaces.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services.Common
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _accessor;
        public IdentityService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public long? Id
        {
            get
            {
                var res = _accessor.HttpContext.User.FindFirst("Id");
                return res is not null ? long.Parse(res.Value) : null;
            }
        }

        public string FullName
        {
            get
            {
                var res = _accessor.HttpContext.User.FindFirst("Name");
                return res != null ? res.Value : string.Empty;
            }
        }

        public string Email
        {
            get
            {
                var res = _accessor.HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
                return res != null ? res.Value : string.Empty;
            }
        }

        public string ImagePath
        {
            get
            {
                var res = _accessor.HttpContext.User.FindFirst("ImagePath");
                return res != null ? res.Value : string.Empty;
            }
        }
     

    }
}

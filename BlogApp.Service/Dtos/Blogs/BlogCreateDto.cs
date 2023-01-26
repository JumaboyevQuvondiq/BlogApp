using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Dtos.Blogs
{
    public class BlogCreateDto
    {
        public string Title { get; set; }  = string.Empty;
        public string Context { get; set; } =string.Empty;
        public IFormFile Image { get; set; }  
    }
}

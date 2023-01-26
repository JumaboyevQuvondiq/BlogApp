using BlogApp.Service.Dtos.Blogs;
using BlogApp.Service.Interfaces.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers.Blogs
{
    [Route("blogs")]
    public class BlogsController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService) {
            _blogService = blogService;
        }
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromForm]BlogCreateDto blogCreateDto)
        {
            if(ModelState.IsValid)
            {
                var res = await _blogService.CreateAsync(blogCreateDto);
                return RedirectToAction("Home", "Index",new {area =""});   
            }
            return Create();
        }
    }
}

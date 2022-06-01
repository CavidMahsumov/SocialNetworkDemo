using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.WebUI.Models;
using SocialProject.WebUI.Entities;
using SocialProject.WebUI.Helpers;
using SocialProject.WebUI.Models;
using SocialProject.WebUI.Services.Abstract;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialNetwork.WebUI.Controllers
{
    public class PostController : Controller
    {
        private IHttpContextAccessor _httpContext;
        private UserManager<CustomIdentityUser> _userManager;
        private readonly IWebHostEnvironment _webhost;
        private IPostRepository _postRepository;

        public PostController(IHttpContextAccessor httpContext, UserManager<CustomIdentityUser> userManager, IWebHostEnvironment webhost, IPostRepository postRepository)
        {
            _httpContext = httpContext;
            _userManager = userManager;
            _webhost = webhost;
            _postRepository = postRepository;
        }

        [HttpPost] 
        public async Task<IActionResult> CreatePost(PostViewModel postViewModel)     
        {
            var userId = _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            var imghelper = new ImageHelper(_webhost);
            var image = await imghelper.SaveFile(postViewModel.File);
            var post = new Post
            {
                UserId = user.Id,
                CustomIdentityUser = user,
                Message = postViewModel.Message,
                ImagePath = image,
                VideoLink = postViewModel.VideoLink,
                LikeCount = 0,
                CommentCount = 0,
                When = DateTime.Now,
            };
            _postRepository.Add(post);

            return RedirectToAction("Index","Home");
        }
    }
}

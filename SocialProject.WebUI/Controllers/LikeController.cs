using Microsoft.AspNetCore.Mvc;
using SocialNetwork.WebUI.Models;
using SocialProject.WebUI.Entities;
using SocialProject.WebUI.Services.Abstract;
using System.Threading.Tasks;

namespace SocialNetwork.WebUI.Controllers
{
    public class LikeController : Controller
    {
        private IPostRepository _postRepository;

        public LikeController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddLike(PostViewModel model)
        {
            Post post = new Post();
            var postid = model.PostId;
            var posts = _postRepository.GetAll();
            post.PostId = postid;
            foreach (var item in posts)
            {
                if (item.PostId == postid)
                {

                     _postRepository.Update(postid);


                }
            }
            return RedirectToAction("Index", "Home");

        }
    }
}

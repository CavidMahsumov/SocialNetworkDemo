using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.WebUI.Entities;
using SocialNetwork.WebUI.Models;
using SocialNetwork.WebUI.Services.Abstract;
using SocialProject.WebUI.Entities;
using SocialProject.WebUI.Services.Abstract;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialNetwork.WebUI.Controllers
{
    public class FriendController : Controller
    {
        private IHttpContextAccessor _httpContext;
        private UserManager<CustomIdentityUser> _userManager;
        private readonly IWebHostEnvironment _webhost;
        private IPostRepository _postRepository;
        private INotficationRepository _notfRepository;
        private IFriendRepository _friendRepository;

        public FriendController(IHttpContextAccessor httpContext, UserManager<CustomIdentityUser> userManager, IWebHostEnvironment webhost, IPostRepository postRepository, INotficationRepository notfRepository, IFriendRepository friendRepository)
        {
            _httpContext = httpContext;
            _userManager = userManager;
            _webhost = webhost;
            _postRepository = postRepository;
            _notfRepository = notfRepository;
            _friendRepository = friendRepository;
        }

        //private INotficationRepository _notfRepository;

        [HttpPost]
        public async Task<IActionResult> SendNotf(PostViewModel model)
        {
            var userId = _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            model.SenderId = userId;
            model.SenderUser = user;
            model.ReceiverUser = await _userManager.FindByIdAsync(model.ReceiverId);

            Notfication notfication = new Notfication()
            {
                Date = DateTime.Now,
                FromUserId = model.SenderId,
                Message = $"{model.SenderUser.Firstname + model.SenderUser.Lastname} send Friend",
                ToUserId = model.ReceiverId,
                FromUser = model.SenderUser,
                ToUser = model.ReceiverUser,
            };




            _notfRepository.Add(notfication);



            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> AddFriend(PostViewModel model)
        {
            var sender = await _userManager.FindByIdAsync(model.SenderId);
            var receiver = await _userManager.FindByIdAsync(model.ReceiverId);
            var friend = new Friend()
            {
                Accepted = true,
                SenderId = model.SenderId,
                ReceiverId = model.ReceiverId,
                ReceiverUser = receiver,
                SenderUser = sender

            };
           
                _notfRepository.Delete(model.CurrentNotfId);

           
            _friendRepository.Add(friend);
            return RedirectToAction("Notification", "Home");
        }
    }
}

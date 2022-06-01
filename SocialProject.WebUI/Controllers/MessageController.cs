using Microsoft.AspNetCore.Mvc;
using SocialNetwork.WebUI.Entities;
using SocialNetwork.WebUI.Helpers;
using SocialNetwork.WebUI.Models;
using SocialNetwork.WebUI.Services.Abstract;
using SocialProject.WebUI.Entities;
using SocialProject.WebUI.Models;
using System;
using System.Threading.Tasks;

namespace SocialNetwork.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private IMessageRepository _messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddMessage(PostViewModel model)
        {
            var chatmodel = new PostViewModel
            {
                CurrentUser = UserHelper.CurUser,
                SelectedUserId = model.SelectedUserId,
                Users=UserHelper.Users


            };

            return View("../Home/Chat",model);
        }
    }
}

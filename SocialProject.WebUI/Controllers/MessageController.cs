using Microsoft.AspNetCore.Mvc;
using SocialNetwork.WebUI.Entities;
using SocialNetwork.WebUI.Helpers;
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
            var message = new Message()
            {
                Date = DateTime.Now

            };
            message.FromUserId = UserHelper.CurrentUserId;
            message.FromUser = UserHelper.CurUser;
            
            if (message != null)
            {
                _messageRepository.Add(message);
            }

            return RedirectToAction("Chat", "Home");
        }
    }
}

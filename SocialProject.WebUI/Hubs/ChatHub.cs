using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using SocialNetwork.WebUI.Entities;
using SocialNetwork.WebUI.Helpers;
using SocialProject.WebUI.Entities;
using System.Threading.Tasks;

namespace SocialNetwork.WebUI.Hubs
{
    public class ChatHub:Hub
    {
        private UserManager<CustomIdentityUser> userManager;
        private IHttpContextAccessor httpContextAccessor;


        public ChatHub(UserManager<CustomIdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task SendMessage(string message)
        {
            var currentUser = UserHelper.CurUser;

            // var receiverUser = userManager.GetUserAsync();

            await Clients.Others.SendAsync("Connect",message);
        }



        //public override async Task OnConnectedAsync()
        //{
        //    var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
        //    UserHelper.ActiveUsers.Add(user);
        //    string info = user.UserName + " connected successfully";
        //    await Clients.Others.SendAsync("Connect", info);
        //}

        //public override async Task OnDisconnectedAsync(Exception? exception)
        //{
        //    var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
        //    var userRemoved = UserHelper.ActiveUsers.SingleOrDefault(u => u.Id == user.Id);
        //    if (userRemoved != null)
        //    {
        //        UserHelper.ActiveUsers.RemoveAll(u => u.Id == userRemoved.Id);
        //        string info = user.UserName + " disconnected";
        //        await Clients.Others.SendAsync("Disconnect", info);
        //    }
        //}

    }
}

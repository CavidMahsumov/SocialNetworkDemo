using SocialProject.WebUI.Entities;
using System.Collections.Generic;

namespace SocialNetwork.WebUI.Models
{
    public class ChatViewModel
    {
        public List<CustomIdentityUser> Users { get; set; }

    

        public CustomIdentityUser CurrentUser { get; set; }
        public List<Post> Posts { get; set; }

        
        public string SelectedUserId { get; set; }
        public string Message { get; set; }

    }
}

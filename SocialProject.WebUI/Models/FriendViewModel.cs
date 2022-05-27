using SocialProject.WebUI.Entities;
using System.Collections;
using System.Collections.Generic;

namespace SocialNetwork.WebUI.Models
{
    public class FriendViewModel
    {
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public CustomIdentityUser RecevierUser { get; set; }
        public CustomIdentityUser SenderUser { get; set; }
        public List<CustomIdentityUser>Users { get; set; }
     

    }
}

using SocialProject.WebUI.Entities;
using System.Collections;
using System.Collections.Generic;

namespace SocialNetwork.WebUI.Models
{
    public class FriendViewModel
    {
        public CustomIdentityUser CurUser { get; set; }
        public List<CustomIdentityUser>Users { get; set; }
     

    }
}

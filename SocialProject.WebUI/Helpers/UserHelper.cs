using SocialProject.WebUI.Entities;
using System.Collections.Generic;

namespace SocialNetwork.WebUI.Helpers
{
    public class UserHelper
    {
        public static string CurrentUserId { get; set; }
        public static CustomIdentityUser CurUser { get; set; }
        public static List<CustomIdentityUser> Users { get; set; }
    }
}

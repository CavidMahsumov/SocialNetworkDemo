using SocialProject.WebUI.Entities;

namespace SocialNetwork.WebUI.Models
{
    public class MessageViewModel
    {
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public CustomIdentityUser FromUser { get; set; }
        public CustomIdentityUser ToUser { get; set; }
        public string Text { get; set; }
       
    }
}

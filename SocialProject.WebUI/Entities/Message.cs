using SocialProject.WebUI.Entities;
using System;

namespace SocialNetwork.WebUI.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public CustomIdentityUser FromUser { get; set; }
        public CustomIdentityUser ToUser { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}

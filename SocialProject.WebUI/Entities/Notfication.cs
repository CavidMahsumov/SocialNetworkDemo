using SocialProject.WebUI.Entities;
using System;

namespace SocialNetwork.WebUI.Entities
{
    public class Notfication
    {
        public int NotficationId { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public virtual CustomIdentityUser FromUser { get; set; }
        public virtual  CustomIdentityUser ToUser { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}

using SocialNetwork.WebUI.Entities;
using SocialProject.WebUI.Entities;
using System.Collections.Generic;

namespace SocialNetwork.WebUI.Models
{
    public class NotificationViewModel
    {

        public NotificationViewModel()
        {
            Notfications = new List<Notfication>();
        }


        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public CustomIdentityUser SenderUser { get; set; }
        public CustomIdentityUser ReceiverUser { get; set; }
        public CustomIdentityUser CurUser { get; set; }
        public List<CustomIdentityUser> Users { get; set; }
        public List<Notfication> Notfications { get; set; }


    }
}

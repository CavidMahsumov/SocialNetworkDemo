using SocialProject.WebUI.Entities;

namespace SocialNetwork.WebUI.Entities
{
    public class Friend
    {
        public int Id { get; set; }//failed
        public string  SenderId { get; set; }
        public virtual CustomIdentityUser SenderUser { get; set; }
        public string ReceiverId { get; set; }
        public virtual CustomIdentityUser ReceiverUser { get; set; }
        public bool Accepted { get; set; }

    }
}

using SocialNetwork.WebUI.Entities;
using System.Collections.Generic;

namespace SocialNetwork.WebUI.Services.Abstract
{
    public interface IMessageRepository
    {
        void Add(Message item);
        void Delete(int id);
        void Update(Message item);
        Message Get(int id);
        IEnumerable<Message> GetAll();
    }
}

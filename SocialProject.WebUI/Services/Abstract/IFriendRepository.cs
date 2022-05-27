using SocialNetwork.WebUI.Entities;
using SocialProject.WebUI.Entities;
using System.Collections.Generic;

namespace SocialNetwork.WebUI.Services.Abstract
{
    public interface IFriendRepository
    {
        void Add(Friend item);
        void Delete(int id);
        void Update(Friend item);
        Friend Get(int id);
        IEnumerable<Friend> GetAll();
    }
}

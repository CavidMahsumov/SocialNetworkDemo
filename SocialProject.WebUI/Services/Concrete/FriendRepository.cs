using SocialNetwork.WebUI.Entities;
using SocialNetwork.WebUI.Services.Abstract;
using SocialProject.WebUI.Entities;
using System.Collections.Generic;

namespace SocialNetwork.WebUI.Services.Concrete
{
    public class FriendRepository : IFriendRepository
    {
        private CustomIdentityDbContext _context;

        public void Add(Friend item)
        {
            _context.Friends.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Friend Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Friend> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Friend item)
        {
            throw new System.NotImplementedException();
        }
    }
}

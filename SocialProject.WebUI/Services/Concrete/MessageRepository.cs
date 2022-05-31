using SocialNetwork.WebUI.Entities;
using SocialNetwork.WebUI.Services.Abstract;
using SocialProject.WebUI.Entities;
using System.Collections.Generic;

namespace SocialNetwork.WebUI.Services.Concrete
{
    public class MessageRepository : IMessageRepository
    {
        public CustomIdentityDbContext _context { get; set; }

        public MessageRepository(CustomIdentityDbContext context)
        {
            _context = context;
        }

        public void Add(Message item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Message Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Message> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Message item)
        {
            throw new System.NotImplementedException();
        }
    }
}

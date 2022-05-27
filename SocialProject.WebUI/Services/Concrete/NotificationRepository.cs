using SocialNetwork.WebUI.Entities;
using SocialNetwork.WebUI.Services.Abstract;
using SocialProject.WebUI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.WebUI.Services.Concrete
{
    public class NotificationRepository : INotficationRepository
    {
        private CustomIdentityDbContext _context;

        public NotificationRepository(CustomIdentityDbContext context)
        {
            _context = context;
        }

        public void Add(Notfication item)
        {
            _context.Notfications.Add(item);  
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Notfication Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Notfication> GetAll()
        {
            return _context.Notfications.ToList();
        }

        public void Update(Notfication item)
        {
            throw new System.NotImplementedException();
        }
    }
}

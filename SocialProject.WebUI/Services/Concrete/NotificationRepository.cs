using SocialNetwork.WebUI.Entities;
using SocialNetwork.WebUI.Helpers;
using SocialNetwork.WebUI.Services.Abstract;
using SocialProject.WebUI.Entities;
using System;
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
            //var notf = _context.Notfications
            //                      join
            //                      .Where(i => i.ToUserId==UserHelper.CurrentUserId)
            //                       .ToList();

            //return notf;
            var downtimeJoinReasons = from d in _context.Notfications
                                      join dr in _context.Users on d.ToUserId equals dr.Id
                                      select new Notfication
                                      {
                                          Date = DateTime.Now,
                                          Message = d.Message,
                                          ToUser = d.ToUser,
                                          ToUserId = d.ToUserId,
                                          FromUser = d.FromUser,
                                          FromUserId = d.FromUserId,

                                      };

            return downtimeJoinReasons.ToList();
        }

        public void Update(Notfication item)
        {
            throw new System.NotImplementedException();
        }
    }
}

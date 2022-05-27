using SocialNetwork.WebUI.Entities;
using System.Collections.Generic;

namespace SocialNetwork.WebUI.Services.Abstract
{
    public interface INotficationRepository
    {
        void Add(Notfication item);
        void Delete(int id);
        void Update(Notfication item);
        Notfication Get(int id);
        IEnumerable<Notfication> GetAll();
    }
}

using SocialProject.WebUI.Entities;
using System.Collections.Generic;

namespace SocialProject.WebUI.Services.Abstract
{
    public interface IPostRepository
    {

        void Add(Post item);
        void Delete(int id);
        void Update(Post item);
        Post Get(int id);
        IEnumerable<Post> GetAll();
    }
}

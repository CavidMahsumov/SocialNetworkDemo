using Microsoft.EntityFrameworkCore;
using SocialProject.WebUI.Entities;
using SocialProject.WebUI.Models;
using SocialProject.WebUI.Services.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialProject.WebUI.Services.Concrete
{
    public class PostRepository : IPostRepository
    {
        private CustomIdentityDbContext _context;

        public PostRepository(CustomIdentityDbContext context)
        {
            _context = context;
        }

        public void Add(Post post)
        {
            foreach (var item in _context.Users)
            {
                item.Posts.Add(post);
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            foreach (var item in _context.Posts)
            {
                if (item.PostId == id)
                {
                    _context.Remove(item);
                }
            }
            _context.SaveChanges();
        }

        public Post Get(int id)
        {
            foreach (var item in _context.Posts)
            {
                if (item.PostId == id)
                {
                    return item;
                }

            }
            return null;
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts;
        }

        public  void Update(int id)
        {
            foreach (var chunk in _context.Users)
            {
                foreach (var item in chunk.Posts)
                {
                    if (item.PostId == id)
                    {
                        ++item.LikeCount;
                        _context.Update(item);
                    }
                }
                _context.SaveChanges();
            }

        }

    }

}

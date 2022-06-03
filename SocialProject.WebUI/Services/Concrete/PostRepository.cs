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
            _context.Posts.Add(post);
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

        public IEnumerable<Post>GetAll()
        {
            return _context.Posts;
        }

        public  void Update(Post post)
        {
            var posts =  GetAll();
            foreach (var item in posts)
            {
                if (item.PostId == post.PostId)
                {
                   item.PostId = post.PostId;
                    item.VideoLink= post.VideoLink;
                    item.When = post.When;
                    item.Message = post.Message;
                    item.UserId = post.UserId;
                    item.CommentCount = post.CommentCount;
                    item.CustomIdentityUser = post.CustomIdentityUser;
                    item.ImagePath = post.ImagePath;
                    item.LikeCount = post.LikeCount;

                }
            }
            _context.SaveChanges();
        }

    }

}

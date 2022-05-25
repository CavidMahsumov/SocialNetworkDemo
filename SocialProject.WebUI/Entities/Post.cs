using System;

namespace SocialProject.WebUI.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string Message { get; set; }

        public string ImagePath { get; set; }

        public string VideoLink { get; set; }

        public int LikeCount { get; set; }

        public int CommentCount { get; set; }
        public DateTime When { get; set; }

        public string UserId { get; set; }

        public virtual CustomIdentityUser CustomIdentityUser { get; set; }




    }
}

using Microsoft.AspNetCore.Http;
using SocialProject.WebUI.Entities;
using System;
using System.Collections.Generic;

namespace SocialNetwork.WebUI.Models
{
    public class PostViewModel
    {
        public List<Post> Posts { get; set; }

        public List<CustomIdentityUser> Users { get; set; }

        public string Message { get; set; }
        public string PostImage { get; set; }

        public string VideoLink { get; set; }
        public CustomIdentityUser CurrentUser { get; set; }
        public IFormFile File { get; set; }
        public string SelectedUserId { get; set; }
        public int PostId { get; set; }

    }
}

using Microsoft.AspNetCore.Http;
using SocialProject.WebUI.Entities;
using System.Collections.Generic;

namespace SocialProject.WebUI.Models
{
    public class UserPageViewModel
    {
        public string ProfileImage { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public string About { get; set; }


        public List<Post> Posts { get; set; }

        public string Message { get; set; }
        public string PostImage { get; set; }

        public IFormFile File { get; set; }

    }
}

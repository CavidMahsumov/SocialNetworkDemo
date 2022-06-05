using Microsoft.AspNetCore.Http;
using SocialNetwork.WebUI.Entities;
using SocialProject.WebUI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public List<Notfication> Notifications { get; set; }
        public string ReceiverId { get; set; }
        public string SenderId { get; set; }
        public CustomIdentityUser SenderUser { get; set; }
        public CustomIdentityUser ReceiverUser { get; set; }
        public int CurrentNotfId { get; set; }
        public IFormFile File2 { get; set; }
        public string ImagePath { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }
        public string About { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }


    }
}

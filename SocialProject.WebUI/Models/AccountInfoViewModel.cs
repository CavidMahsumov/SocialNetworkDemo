using Microsoft.AspNetCore.Http;

namespace SocialProject.WebUI.Models
{
    public class AccountInfoViewModel
    {
        public IFormFile File { get; set; }
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
    }
}

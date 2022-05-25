using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialProject.WebUI.Entities
{
    public class CustomIdentityUser : IdentityUser
    {
        public CustomIdentityUser()
        {
            Posts = new List<Post>();
        }
        public string ImageUrl { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
        public string Country { get; set; }

        public string Address { get; set; }
        public string About { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Linkedin { get; set; }

        public string Instagram { get; set; }

        public string Github { get; set; }

        public string Google { get; set; }

        public  ICollection<Post> Posts { get; set; }



    }
}

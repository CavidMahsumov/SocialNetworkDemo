using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SocialProject.WebUI.Entities;
using SocialProject.WebUI.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialProject.WebUI.ViewComponents
{
    public class ProfilePictureViewComponent : ViewComponent
    {

        private IHttpContextAccessor _httpContext;
        private UserManager<CustomIdentityUser> _userManager;

        public ProfilePictureViewComponent(IHttpContextAccessor httpContext, UserManager<CustomIdentityUser> userManager)
        {
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public  async  Task<ViewViewComponentResult> InvokeAsync()
        {
            var user = await GetCurrentUser();
            var model = new ProfilePictureViewModel
            {
                ProfileUrl = user.ImageUrl
            };
            return View(model);
        }


        public async Task<CustomIdentityUser> GetCurrentUser()
        {
            var userId = _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }
    }
}

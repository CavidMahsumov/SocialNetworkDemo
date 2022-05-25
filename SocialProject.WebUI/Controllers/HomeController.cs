using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialProject.WebUI.Entities;
using SocialProject.WebUI.Helpers;
using SocialProject.WebUI.Models;
using SocialProject.WebUI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialProject.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IHttpContextAccessor _httpContext;
        private UserManager<CustomIdentityUser> _userManager;
        private readonly IWebHostEnvironment _webhost;
        private IPostRepository _postRepository;


        public HomeController(IHttpContextAccessor httpContext, UserManager<CustomIdentityUser> userManager, IWebHostEnvironment webhost, IPostRepository postRepository)
        {
            _httpContext = httpContext;
            _userManager = userManager;
            _webhost = webhost;
            _postRepository = postRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var users = _userManager.Users.ToList();

            var model = new PostViewModel
            {
                Posts = _postRepository.GetAll().Reverse().ToList(),
                Users = users
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Index(PostViewModel model)
        {
            var user = await GetUser();
            var helper = new ImageHelper(_webhost);
            var image = await helper.SaveFile(model.File);
            var post = new Post
            {
                UserId = user.Id,
                CustomIdentityUser = user,
                Message = model.Message,
                ImagePath = image,
                VideoLink=model.VideoLink,
                LikeCount = 0,
                CommentCount = 0,
                When = DateTime.Now,
            };
            _postRepository.Add(post);
            return RedirectToAction("Index");
        }


        public IActionResult Badge()
        {
            return View();
        }

        public IActionResult Story()
        {
            return View();
        }

        public IActionResult Group()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserPage()
        {
            var user = await GetUser();

            var model = new UserPageViewModel
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                EmailAddress = user.Email,
                ProfileImage = user.ImageUrl,
                About = user.About,
                Posts = _postRepository.GetAll().Where(u => u.UserId == user.Id).Reverse().ToList()
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> UserPage(UserPageViewModel model)
        {
            var user = await GetUser();
            var helper = new ImageHelper(_webhost);
            var image = await helper.SaveFile(model.File);
            var post = new Post
            {
                UserId = user.Id,
                CustomIdentityUser = user,
                Message = model.Message,
                ImagePath = image,
                LikeCount = 0,
                CommentCount = 0,
                When = DateTime.Now,
            };
            _postRepository.Add(post);
            return RedirectToAction("UserPage");
        }

        public IActionResult Email()
        {
            return View();
        }
        public IActionResult Hotel()
        {
            return View();
        }

        public IActionResult Event()
        {
            return View();
        }

        public IActionResult Live()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult Analytics()
        {
            return View();
        }

        public IActionResult Chat()
        {
            return View();
        }
        public IActionResult Video()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }


        public async Task<IActionResult> AccountInformation()
        {
            var user = await GetUser();

            var model = new AccountInfoViewModel
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Address = user.Address,
                About = user.About,
                City = user.City,
                Country = user.Country,
                Phone = user.PhoneNumber,
                PostCode = user.PostCode,
                ImagePath = user.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AccountInformation(AccountInfoViewModel model)
        {
            var user = await GetUser();
            if (model.File != null)
            {
                var Helper = new ImageHelper(_webhost);
                model.ImagePath = await Helper.SaveFile(model.File);
            }

            user.Firstname = model.Firstname;
            user.Lastname = model.Lastname;
            user.Email = model.Email;
            user.Address = model.Address;
            user.About = model.About;
            user.PhoneNumber = model.Phone;
            user.Country = model.Country;
            user.City = model.City;
            user.PostCode = model.PostCode;
            if (model.ImagePath != null)
            {
                user.ImageUrl = model.ImagePath;
            }
            await _userManager.UpdateAsync(user);
            return RedirectToAction("AccountInformation");
        }


        public async Task<IActionResult> ContactInformation()
        {
            var user = await GetUser();

            var model = new SavedAddressViewModel
            {
                Country = user.Country,
                City = user.City,
                Address = user.Address,
                Postcode = user.PostCode
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ContactInformation(SavedAddressViewModel model)
        {
            var user = await GetUser();

            user.Country = model.Country;
            user.City = model.City;
            user.Address = model.Address;
            user.PostCode = model.Postcode;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("ContactInformation");
        }


        public async Task<IActionResult> Social()
        {
            var user = await GetUser();
            var model = new SocialAccountViewModel
            {
                Facebook = user.Facebook,
                Instagram = user.Instagram,
                Twitter = user.Twitter,
                Google = user.Google,
                Github = user.Github,
                Linkedin = user.Linkedin
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Social(SocialAccountViewModel model)
        {
            var user = await GetUser();

            user.Facebook = model.Facebook;
            user.Instagram = model.Instagram;
            user.Twitter = model.Twitter;
            user.Linkedin = model.Linkedin;
            user.Google = model.Google;
            user.Github = model.Github;
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Social");
        }

        public IActionResult Payment()
        {
            return View();
        }

        public IActionResult Notification()
        {
            return View();
        }

        public IActionResult HelpBox()
        {
            return View();
        }

        public IActionResult SingleProduct()
        {
            return View();
        }
        public IActionResult Member()
        {
            return View();
        }


        public IActionResult OpenEmail()
        {
            return View();
        }


        public IActionResult HotelDetails()
        {
            return View();
        }



        //methods
        public async Task<CustomIdentityUser> GetUser()
        {
            var userId = _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }





    }
}

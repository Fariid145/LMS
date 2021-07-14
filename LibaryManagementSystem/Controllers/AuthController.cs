using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using LibaryManagementSystem.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LibaryManagementSystem.Interfaces;

namespace SimpleAuthentication.Controllers
{
    public class AuthController : Controller
    {

        public IUserService _userService;
        public IUserRepository _userRepository;

        public AuthController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User vm)
        {
       
            _userService.RegisterUser(vm.Email, vm.FirstName, vm.LastName, vm.Gender, vm.Password, vm.ConfirmPassword);
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User vm)
        {
            // var RoleId = User.RoleId;

            User user = _userService.Login(vm.Email, vm.Password);

            if (user == null) return View();

           
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var props = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);


                if(user.RoleId == 1)
                {
                    return RedirectToAction("Index", "AdminDashBoard");
                }
                else
                {
                    return RedirectToAction("Index", "AdminDashBoard");
                }

                


             
            
           
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }



    }
}

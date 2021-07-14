using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LibaryManagementSystem.Interfaces;
using LibaryManagementSystem.Models;
using LibaryManagementSystem.Models.ViewModels;
using LibaryManagementSystem.Repositories;
using LibaryManagementSystem.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace LibaryManagementSystem.Controllers
{
    // [Authorize(Roles = "Administrator")]
    public class UserController : Controller
    {
       
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View(_userService.GetAll());
        }

        // public  IActionResult Details(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var user = _userService.FindById(id.Value);
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(user);
        // }
        
        [HttpGet]
         [AllowAnonymous]
          public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {

            _userService.RegisterUser(user.Email, user.FirstName, user.LastName, user.Gender, user.Password, user.ConfirmPassword);
            return RedirectToAction("Index", "Dashboard");
        }
        // [HttpGet]
        // public IActionResult Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var user = _userService.FindById(id.Value);
        //     if (user== null)
        //     {
        //         return NotFound();
        //     }
        //     return View(user);
        // }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public IActionResult Edit(int id, User user)
        // {
        //     if (id != user.Id)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         _userService.Update(user);
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(user);
        // }

     
        // public IActionResult Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var customer = _userService.FindById(id.Value);
        //     if (customer == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(customer);
        // }

       
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public IActionResult DeleteConfirmed(int id)
        // {
            
        //     _userService.Delete(id);
        //     return RedirectToAction(nameof(Index));
        // }


        

        // [HttpGet]
        // [AllowAnonymous]
        // public IActionResult Logout()
        // {

        //     HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //     return RedirectToAction("Login");
        // }

        [HttpGet]
        // [AllowAnonymous]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string username, string password, bool isCheckout = false)
        {

            var customer = _userService.Login(username, password);
            if (customer == null)
            {
                ViewBag.Message = "Invalid Username/Password";
                if (isCheckout)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                return View();
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{customer.FirstName}"),
                    new Claim(ClaimTypes.GivenName, $"{customer.FirstName} {customer.LastName}"),
                    new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
                    new Claim(ClaimTypes.Email, customer.Email),
                    new Claim(ClaimTypes.Role, "Customer"),
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                return isCheckout? RedirectToAction("Index", "Dashboard") : RedirectToAction("Index", "Home");
            }

        }
    }

}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LibaryManagementSystem.Models;
using LibaryManagementSystem.Models.ViewModels;
using LibaryManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LibaryManagementSystem.Interfaces;

namespace ProductReviewAuthentication.Controllers
{
    [Authorize]
    public class AdminDashBoardController : Controller
    {
        
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
    

        public AdminDashBoardController( IUserService userService, IBookService bookService)
        {
          
          _bookService = bookService;
            _userService = userService;
        }
        public IActionResult Index()
        {
           
             return View();
        }
        public IActionResult Register()
        {
           
            return View();
        }
        public IActionResult Register(User user)
        {
           _userService.RegisterUser(user.Email, user.FirstName,user.LastName,user.Gender, user.Password, user.ConfirmPassword);
            return RedirectToAction("ListUser");
        }
        
        public IActionResult ListUser()
        {
            var users = _userService.GetAll();
            return View(users);
        }
        public IActionResult Delete(int id)
        {
            var users = _userService.FindById(id);
            if(users == null)
            {
                return NotFound();
            }
            _userService.Delete(id);
             return RedirectToAction("ListUser");
        }
        public IActionResult GetBooks()
        {
            ViewBag.Books = _bookService.GetAll();
            var bookRecord = _bookService.GetAll();
            return View(bookRecord);
        }
    }
}

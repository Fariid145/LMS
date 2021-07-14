using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Mvc;
 using LibaryManagementSystem.Models;
 using LibaryManagementSystem.Services;
 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Security.Claims;
 using System.Threading.Tasks;
using LibaryManagementSystem.Interfaces;

namespace LibaryManagementSystem.Controllers
{
   public class DashBoardController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        public DashBoardController(IUserService userService, IBookService bookService)
        {
            _bookService = bookService;
            _userService = userService;
        }
           public IActionResult Index()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            User user = _userService.FindById(userId);

            ViewBag.UserName = $"{user.FirstName}";
            return View();
        }


         
//         
         
    }
}
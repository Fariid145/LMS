using System.Collections.Generic;
using LibaryManagementSystem.Interfaces;
using LibaryManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibaryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;

         public BookController(IBookService bookService,  ICategoryService categoryService)
        {
            _bookService = bookService;
           
            _categoryService = categoryService;
        }
         public IActionResult Index()
        {
            return View(_bookService.GetAll());
        }
          [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = _bookService.GetBook(id.Value);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
           [HttpGet]
        public IActionResult Create()
        {
            List<Category> categories = _categoryService.GetAll();
            List<SelectListItem> listAllBooks = new List<SelectListItem>();
            foreach (Category category in categories)
            {
                SelectListItem book = new SelectListItem(category.Name, category.Id.ToString());
                listAllBooks.Add(book);
            }

            ViewBag.Categories = listAllBooks;
            return View();
        }
           [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Books book)
        {
            if (ModelState.IsValid)
            {
                if(book != null)
                {
                    
                _bookService.AddBook(book);
                return RedirectToAction(nameof(Index));
                }
            }
            return View(book);
        }
        
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = _bookService.GetBook(id.Value);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
           [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Books book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
          public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = _bookService.GetBook(id.Value);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
           [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }


    }
}



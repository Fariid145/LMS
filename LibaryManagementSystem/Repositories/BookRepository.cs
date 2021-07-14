using System.Linq;
using System;
using LibaryManagementSystem.Interfaces;
using LibaryManagementSystem.Models;
using System.Collections.Generic;

namespace LibaryManagementSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
           private readonly LibaryManagementDBContext _dbContext;
        public BookRepository(LibaryManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Books AddBook(Books book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return book;
        }

        public void DeleteBook(int id)
        {
            var book = _dbContext.Books.Find(id);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            return _dbContext.Books.Any(b => b.Id == id);
        }

        public List<Books> GetAll()
        {
            return _dbContext.Books.ToList();
        }

        public Books GetBook(int id)
        {
            return _dbContext.Books.Find(id);
        }

        public Books UpdateBook(Books book)
        {
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
            return book;
        }

        
    }
}







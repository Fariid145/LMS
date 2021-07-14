using System.Collections.Generic;
using LibaryManagementSystem.Interfaces;
using LibaryManagementSystem.Models;

namespace LibaryManagementSystem.Services
{
    public class BookService : IBookService
    {
            private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Books AddBook(Books book)
        {
            return _bookRepository.AddBook(book);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }

        public List<Books> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Books GetBook(int id)
        {
            return _bookRepository.GetBook(id);
        }

        public Books UpdateBook(Books book)
        {
            return _bookRepository.UpdateBook(book);
        }

        
    }
}

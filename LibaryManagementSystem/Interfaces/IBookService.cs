using System;
using System.Collections.Generic;
using LibaryManagementSystem.Models;

namespace LibaryManagementSystem.Interfaces
{
    public interface IBookService
    {
        
        public List<Books> GetAll();

        public Books GetBook(int id);

        public Books AddBook(Books book);

        public Books UpdateBook(Books book);

        public void DeleteBook(int id);
    }
}


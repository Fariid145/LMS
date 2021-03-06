using System.Collections.Generic;
using LibaryManagementSystem.Models;

namespace LibaryManagementSystem.Interfaces
{
    public interface ICategoryService
    {
       public Category FindById(int id);

        public Category Create(Category category);

        public Category Update(Category category);

        public void Delete(int id);

        public List<Category> GetAll();

        public bool Exists(int id);
    }
}
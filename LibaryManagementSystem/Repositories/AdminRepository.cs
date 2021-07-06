using System;
using LibaryManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace LibaryManagementSystem.Repositories
{
    public class AdminRepository
    {
         private readonly LibaryManagementDBContext _dbContext;
          public AdminRepository(LibaryManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }
         public Admin FindById(int id)
        {
            return _dbContext.Admins.Find(id);
        }
          public Admin Create(Admin admin)
        {
            _dbContext.Admins.Add(admin);
            _dbContext.SaveChanges();
            return admin;
        }

        public Admin Update(Admin admin)
        {
            _dbContext.Admins.Update(admin);
            _dbContext.SaveChanges();
            return admin;
        }

        public void Delete(int id)
        {
          
            var admin = new Admin
            {
               Id = id
            };
            if (admin != null)
            {
                _dbContext.Admins.Remove(admin);
                _dbContext.SaveChanges();
            }
        }

        public List<Admin> GetAll()
        {
            return _dbContext.Admins.ToList();

        }

        public bool Exists(int id)
        {
            return _dbContext.Admins.Any(e => e.Id == id);
        }

        public Admin FindByEmail(string email)
        {
            return _dbContext.Admins.FirstOrDefault(e => e.Email == email);
        }
    }
}






    

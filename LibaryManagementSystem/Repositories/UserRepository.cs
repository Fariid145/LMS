using System;
using System.Collections.Generic;
using System.Linq;
using LibaryManagementSystem.Interfaces;
using LibaryManagementSystem.Models;

namespace LibaryManagementSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibaryManagementDBContext _dbContext;
        public UserRepository(LibaryManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }
          public User FindById(int id)
        {
            return _dbContext.Users.Find(id);
        }
         public User Create(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }
          public User Update(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return user;
        }
          public void Delete(int id)
        {
            var user = FindById(id);


            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }
            public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }
         public bool Exists(int id)
        {
            return _dbContext.Users.Any(e => e.Id == id);
        }
         public Role FindRole(string name)
        {
            return  _dbContext.Roles.FirstOrDefault(r => r.Name.Equals(name));
        }


        public User FindByUsername(string name)
        {
            return _dbContext.Users.FirstOrDefault(c => c.FirstName == name);
        }

        public Role FindRole(string name, string userType)
        {
            throw new NotImplementedException();
        }

        public Role FindRole()
        {
            throw new NotImplementedException();
        }
    }
}




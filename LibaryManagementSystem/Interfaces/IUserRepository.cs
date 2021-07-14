using System;
using System.Collections.Generic;
using LibaryManagementSystem.Models;

namespace LibaryManagementSystem.Interfaces
{
    public interface IUserRepository
    {
        public User FindById(int id);

        public User Create(User user);

        public User Update(User user);

        public void Delete(int id);

        public List<User> GetAll();

        public bool Exists(int id);

        public User FindByUsername(string name);
        
        public Role FindRole(string name);
       
    }
}



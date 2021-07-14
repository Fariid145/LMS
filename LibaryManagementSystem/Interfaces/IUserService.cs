using System.Collections.Generic;
using LibaryManagementSystem.Models;

namespace LibaryManagementSystem.Interfaces
{
    public interface IUserService
    {
        public User FindById(int id);

        public void RegisterUser(string email, string firstName,string lastName, string gender, string password, string confirmPassword);

        public User Update(User user);

        public void Delete(int id);

        public List<User> GetAll();

        public bool Exists(int id);

        public User Login(string username, string password);
    }
}
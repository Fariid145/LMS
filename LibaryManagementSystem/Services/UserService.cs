using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using LibaryManagementSystem.Interfaces;
using LibaryManagementSystem.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace LibaryManagementSystem.Services
{
    public class UserService : IUserService
    {
          private readonly IUserRepository userRepository;
        //   private readonly IAdminRepository adminRepository;
            public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
         public void RegisterUser(string email, string lastName, string firstName, string gender, string password, string confirmPassword)
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string saltString = Convert.ToBase64String(salt);

            string hashedPassword = HashPassword(password, saltString);

            User user = new User
            {
              
                Email = email,
                LastName = lastName,
                FirstName = firstName,
                Gender = gender,
                HashSalt = saltString,
                PasswordHash = hashedPassword,
                Role = userRepository.FindRole("user")
             
            };

        }
           private string HashPassword(string password, string salt)
        {
            byte[] saltByte = Convert.FromBase64String(salt);
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltByte,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            Console.WriteLine($"Hashed: {hashed}");

            return hashed;
        }
          public void Delete(int id)
        {
            userRepository.Delete(id);
        }

        public User FindById(int id)
        {
            return userRepository.FindById(id);
        }

        public User Update(User user)
        {
            return userRepository.Update(user);
        }

        public List<User> GetAll()
        {
            return userRepository.GetAll();

        }

        public bool Exists(int id)
        {
            return userRepository.Exists(id);
        }

        public User Login(string username, string password)
        {
            var user = userRepository.FindByUsername(username);
            if (user == null || user.Password != password)
            {
                return null;
            }

            return user;
        }
        public User Create(User user)
        {
            return userRepository.Create(user);
        }

        // public void RegisterUser(string email, string firstName, string lastName, string gender, string password)
        // {
        //     throw new NotImplementedException();
        // }
    }
}





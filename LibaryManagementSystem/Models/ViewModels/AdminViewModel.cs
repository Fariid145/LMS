using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace LibaryManagementSystem.Models.ViewModels
{
    public class AdminViewModel
    {
         
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public class RegisterAdminViewModel
    {
        [Required(ErrorMessage = "User first name is required")]
        [Display(Name = "FirstName:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "User last name is required")]
        [Display(Name = "LastName:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "User E-mail is required")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User Password is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password!!")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [Display(Name = "Gender:")]
        public string Gender { get; set; }
    }

    public class LoginAdminViewModel
    {
        [Required(ErrorMessage = "User E-mail is required")]
        [Display(Name = "email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User Password is required")]
        [Display(Name = "Password:")]
        public string Password { get; set; }
    }
    }
}
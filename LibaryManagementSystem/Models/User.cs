using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibaryManagementSystem.Models
{
    public class User : BaseEntity
    {
        //  public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string HashSalt { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public int Age{get; set;}
    
        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(24)]
        public string PhoneNumber { get; set; }

        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public string Gender { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [DisplayName("Username")]
        [StringLength(16)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Confirm Password!!")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }



    }
}
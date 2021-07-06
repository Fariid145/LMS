using System;
namespace LibaryManagementSystem.Models
{
    public class Liberian : BaseEntity
    {
        public string Name { get; set; }
        public int Age{get; set;}
        public string Email { get; set; }
        public string Address{get; set;}
        public string Gender { get; set; }
        
    }
}
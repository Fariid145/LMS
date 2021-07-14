using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibaryManagementSystem.Models
{
    public class Category : BaseEntity
    {
     [Required(ErrorMessage = "Category name is required")]
        [Display(Name = "Category Name")]
        public string Name { get; set;  }

        public List<Books> Books { get; set; } = new List<Books>();
    }
}
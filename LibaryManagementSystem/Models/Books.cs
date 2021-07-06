using  System;
namespace LibaryManagementSystem.Models
{
    public class Books : BaseEntity
    {
        public string Name { get; set; }

        public int ShelfNumber{get; set;}

        public int ISBN{get; set;}
        
        public string Author{get; set;}


    }
}
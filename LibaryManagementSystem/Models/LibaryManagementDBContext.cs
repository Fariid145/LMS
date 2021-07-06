using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryManagementSystem.Models
{
    public class LibaryManagementDBContext : DbContext
    {
          public LibaryManagementDBContext(DbContextOptions<LibaryManagementDBContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<Books> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Liberian> Liberians { get; set; }

    }
}
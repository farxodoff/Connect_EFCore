using System;
using System.Collections.Generic;
using System.Text;
using Connect_EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Connect_EFCore.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ConnectEF;Username=postgres;Password=postgres"); 

        }
    }
}

using System;
using EmployeeData.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeData
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Employee> Employees { get; set; }
    }
}
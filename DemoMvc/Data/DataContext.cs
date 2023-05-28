using DemoMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMvc.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}

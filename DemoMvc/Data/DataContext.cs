using DemoMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMvc.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Incharge> Incharge { get; set; }
    }
}
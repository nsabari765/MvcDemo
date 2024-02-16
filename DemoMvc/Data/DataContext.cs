using DemoMvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoMvc.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Incharge> Incharge { get; set; }
        public DbSet<HodName> HodName { get; set; }
        public DbSet<RegistrationDetails> RegistrationDetails { get; set; }
    }
}
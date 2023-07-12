using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DataContactAPI : DbContext
    {
        public DataContactAPI(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}
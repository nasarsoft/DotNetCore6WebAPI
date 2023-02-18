using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class FullStackDbContext:DbContext
    {

        public FullStackDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApiDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {

        }

        public DbSet<Registration> Registers { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Collar> Collars { get; set; }

        public DbSet<Login> LoggedIn { get; set; }

        public DbSet<Shift> Shifts { get; set; }

    }
}
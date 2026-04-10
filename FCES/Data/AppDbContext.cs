using Microsoft.EntityFrameworkCore;
using FCES.Models;
using FCES.Controllers;

namespace FCES.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Certificates> Certificates { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
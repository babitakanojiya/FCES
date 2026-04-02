using Microsoft.EntityFrameworkCore;
using FCES.Models;

namespace FCES.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Certificate_Verification> Certificates { get; set; }
    }
}
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Model> Models { get; set; }
    }
}
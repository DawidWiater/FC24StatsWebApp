using Microsoft.EntityFrameworkCore;
using FC24StatsWebApp.Models;

namespace FC24StatsWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}

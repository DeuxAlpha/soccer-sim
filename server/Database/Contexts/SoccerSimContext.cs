using System.Reflection;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Contexts
{
    public class SoccerSimContext : DbContext
    {
        public SoccerSimContext()
        {
        }

        public SoccerSimContext(DbContextOptions options) : base(options){}

        public DbSet<Team> Teams { get; set; }
        public DbSet<Competition> Competitions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseSqlServer(
                "Server=localhost,20240;Database=soccer-sim;User Id=sa;Password=Your_password123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
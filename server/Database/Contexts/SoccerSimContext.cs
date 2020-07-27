using System;
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
        public DbSet<League> Competitions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<LeagueGameDay> LeagueGameDays { get; set; }
        public DbSet<LeagueFixture> LeagueFixtures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseSqlServer(Configuration.StaticConfig.GetValue<string>("ConnectionStrings:Development"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
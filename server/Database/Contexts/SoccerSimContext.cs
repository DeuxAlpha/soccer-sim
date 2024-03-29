﻿using System;
using System.Reflection;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Config2;

namespace Database.Contexts
{
    public class SoccerSimContext : DbContext
    {
        public SoccerSimContext()
        {
        }

        public SoccerSimContext(DbContextOptions options) : base(options){}

        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<LeagueGameDay> LeagueGameDays { get; set; }
        public DbSet<LeagueFixture> LeagueFixtures { get; set; }
        public DbSet<LeagueFixtureEvent> LeagueFixtureEvents { get; set; }
        public DbSet<PromotionSystem> PromotionSystems { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<CompetitionRound> CompetitionRounds { get; set; }
        public DbSet<CompetitionRoundFixture> CompetitionFixtures { get; set; }
        public DbSet<CompetitionRoundFixtureEvent> CompetitionFixtureEvents { get; set; }
        public DbSet<CompetitionRoundGameDay> CompetitionGameDays { get; set; }
        public DbSet<CompetitionRoundGroup> CompetitionGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            if (optionsBuilder.IsConfigured) return;
            const string fallbackConnectionString =
                "Server=localhost,20240;Database=SoccerSim;User Id=sa;Password=Your_password123";
            var connectionString = StaticConfig.GetValue<string>("ConnectionStrings:Development");
            if (string.IsNullOrWhiteSpace(connectionString)) connectionString = fallbackConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
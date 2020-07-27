﻿using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class LeagueGameDaysConfiguration : IEntityTypeConfiguration<LeagueGameDay>
    {
        public void Configure(EntityTypeBuilder<LeagueGameDay> builder)
        {
            builder.HasKey(d => new {d.LeagueName, d.Year, d.GameDayNumber});

            builder.HasOne(d => d.League)
                .WithMany(l => l.LeagueGameDays)
                .HasForeignKey(d => new {d.LeagueName, d.Year})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Property(d => d.LeagueName).HasMaxLength(255).IsRequired();

            builder.Property(d => d.Year).HasMaxLength(10).IsRequired();

            builder.Property(d => d.GameDayNumber).IsRequired();
        }
    }
}
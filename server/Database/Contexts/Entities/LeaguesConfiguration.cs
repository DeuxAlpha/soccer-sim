using System;
using Database.Enums;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class LeaguesConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder.HasKey(l => new {l.Name, l.Season});

            builder.HasOne(d => d.Division)
                .WithMany(l => l.Leagues)
                .HasForeignKey(l => new {l.DivisionName, l.Season})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Property(l => l.Season).HasMaxLength(10).IsRequired();

            builder.Property(l => l.Name).HasMaxLength(255).IsRequired();

            builder.Property(l => l.Abbreviation).HasMaxLength(10);

            builder.Property(l => l.PaceModifier).HasDefaultValue(1).IsRequired();

            builder.Property(l => l.ShotAccuracyModifier).HasDefaultValue(1).IsRequired();

            builder.Property(l => l.MaxHomeAdvantage).HasDefaultValue(0).IsRequired();

            builder.Property(l => l.MaxAwayDisadvantage).HasDefaultValue(0).IsRequired();

            builder.Property(l => l.ActionsPerMinute).HasDefaultValue(4).IsRequired();

            builder.Property(l => l.MaxProgressChance).HasDefaultValue(0.7).IsRequired();

            builder.Property(l => l.MinProgressChance).HasDefaultValue(0.3).IsRequired();

            builder.Property(l => l.Rounds).HasDefaultValue(2).IsRequired();
        }
    }
}
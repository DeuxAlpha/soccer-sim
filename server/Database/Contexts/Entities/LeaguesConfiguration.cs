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
            builder.HasKey(c => new {c.Name, c.Season});

            builder.HasOne(c => c.Division)
                .WithMany(c => c.Leagues)
                .HasForeignKey(c => new {c.DivisionName, c.Season})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Property(c => c.Season).HasMaxLength(10).IsRequired();

            builder.Property(c => c.Name).HasMaxLength(255).IsRequired();

            builder.Property(c => c.Abbreviation).HasMaxLength(10);

            builder.Property(c => c.PaceModifier).HasDefaultValue(1).IsRequired();

            builder.Property(c => c.ShotAccuracyModifier).HasDefaultValue(1).IsRequired();

            builder.Property(c => c.MaxHomeAdvantage).HasDefaultValue(0).IsRequired();

            builder.Property(c => c.MaxAwayDisadvantage).HasDefaultValue(0).IsRequired();
        }
    }
}
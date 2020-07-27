using System;
using Database.Enums;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class CompetitionsConfiguration : IEntityTypeConfiguration<Competition>
    {
        public void Configure(EntityTypeBuilder<Competition> builder)
        {
            builder.HasKey(c => new {c.Name, c.Year});

            builder.HasOne(c => c.Country)
                .WithMany(c => c.Competitions)
                .HasForeignKey(c => new {c.CountryName, c.Year})
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.Property(c => c.Year).HasMaxLength(4).IsRequired();

            builder.Property(c => c.Name).HasMaxLength(255).IsRequired();

            builder.Property(c => c.Abbreviation).HasMaxLength(10);

            builder.Property(c => c.CompetitionType)
                .HasMaxLength(20)
                .HasConversion(
                    v => v.ToString(),
                    v => (CompetitionType) Enum.Parse(typeof(CompetitionType), v)).IsRequired();

            builder.Property(c => c.PaceModifier).HasDefaultValue(1).IsRequired();

            builder.Property(c => c.ShotAccuracyModifier).HasDefaultValue(1).IsRequired();

            builder.Property(c => c.MaxHomeAdvantage).HasDefaultValue(0).IsRequired();

            builder.Property(c => c.MaxAwayDisadvantage).HasDefaultValue(0).IsRequired();
        }
    }
}
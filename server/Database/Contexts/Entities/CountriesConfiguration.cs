﻿using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class CountriesConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => new {c.Name, c.Year});

            builder.Property(c => c.Year).HasMaxLength(4).IsRequired();

            builder.Property(c => c.Name).HasMaxLength(255).IsRequired();

            builder.Property(c => c.Abbreviation).HasMaxLength(3).IsRequired();

            builder.Property(c => c.AttackStrength).HasDefaultValue(600).IsRequired();

            builder.Property(c => c.DefenseStrength).HasDefaultValue(600).IsRequired();

            builder.Property(c => c.GoalieStrength).HasDefaultValue(600).IsRequired();

            builder.Property(c => c.MaxPace).HasDefaultValue(40).IsRequired();

            builder.Property(c => c.ShotOnGoalRate).HasDefaultValue(0.4).IsRequired();

            builder.Property(c => c.PotentialPositiveShift).HasDefaultValue(10).IsRequired();

            builder.Property(c => c.PotentialPositiveChance).HasDefaultValue(0.1).IsRequired();

            builder.Property(c => c.PotentialNegativeShift).HasDefaultValue(10).IsRequired();

            builder.Property(c => c.PotentialPositiveChance).HasDefaultValue(0.1).IsRequired();
        }
    }
}
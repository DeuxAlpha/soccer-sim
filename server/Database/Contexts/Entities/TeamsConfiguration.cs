using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class TeamsConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("ID").IsRequired();

            builder.Property(t => t.Name).HasMaxLength(255).IsRequired();

            builder.Property(t => t.ShortName).HasMaxLength(255);

            builder.Property(t => t.Abbreviation).HasMaxLength(3).IsRequired();

            builder.Property(t => t.AttackStrength).HasDefaultValue(600).IsRequired();

            builder.Property(t => t.DefenseStrength).HasDefaultValue(600).IsRequired();

            builder.Property(t => t.GoalieStrength).HasDefaultValue(600).IsRequired();

            builder.Property(t => t.MaxPace).HasDefaultValue(40).IsRequired();

            builder.Property(t => t.ShotOnGoalRate).HasDefaultValue(0.4).IsRequired();

            builder.Property(t => t.PotentialNegativeShift).HasDefaultValue(10).IsRequired();

            builder.Property(t => t.PotentialNegativeChance).HasDefaultValue(0.1).IsRequired();

            builder.Property(t => t.PotentialPositiveShift).HasDefaultValue(10).IsRequired();

            builder.Property(t => t.PotentialPositiveChance).HasDefaultValue(0.1).IsRequired();
        }
    }
}
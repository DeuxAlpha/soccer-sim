using Database.Enums;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class CompetitionRoundsConfiguration : IEntityTypeConfiguration<CompetitionRound>
    {
        public void Configure(EntityTypeBuilder<CompetitionRound> builder)
        {
            builder.HasKey(r => new {r.CompetitionName, r.Season, r.Round});

            builder.HasOne(r => r.Competition)
                .WithMany(c => c.Rounds)
                .HasForeignKey(r => new {r.CompetitionName, r.Season})
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Property(r => r.Season).HasMaxLength(10).IsRequired();

            builder.Property(r => r.CompetitionName).HasMaxLength(255).IsRequired();

            builder.Property(r => r.Round).IsRequired();

            builder.Property(r => r.ReverseFixtureStructure)
                .HasConversion<string>()
                .HasDefaultValue(ReverseFixtureStructure.Default)
                .IsRequired();

            builder.Property(r => r.ComparisonRule)
                .HasConversion<string>()
                .HasDefaultValue(ComparisonRule.Default)
                .IsRequired();
        }
    }
}
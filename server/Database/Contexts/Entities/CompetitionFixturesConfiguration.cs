using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class CompetitionFixturesConfiguration : IEntityTypeConfiguration<CompetitionRoundFixture>
    {
        public void Configure(EntityTypeBuilder<CompetitionRoundFixture> builder)
        {
            builder.HasKey(f => new
            {
                f.CompetitionName, f.Season, f.RoundNumber, f.GameDayNumber, f.HomeTeamName, f.AwayTeamName
            });

            builder.HasOne(f => f.Competition)
                .WithMany(c => c.Fixtures)
                .HasForeignKey(f => new {f.CompetitionName, f.Season})
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(f => f.GameDay)
                .WithMany(gd => gd.Fixtures)
                .HasForeignKey(f => new {f.CompetitionName, f.Season, f.RoundNumber, f.GroupName, f.GameDayNumber})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(f => f.HomeTeam)
                .WithMany(t => t.HomeCompetitionFixtures)
                .HasForeignKey(f => new {f.HomeTeamName, f.Season})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(f => f.AwayTeam)
                .WithMany(t => t.AwayCompetitionFixtures)
                .HasForeignKey(f => new {f.AwayTeamName, f.Season})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Property(f => f.CompetitionName).HasMaxLength(255).IsRequired();

            builder.Property(f => f.Season).HasMaxLength(10).IsRequired();

            builder.Property(f => f.RoundNumber).IsRequired();

            builder.Property(f => f.GroupName).HasMaxLength(100).IsRequired();

            builder.Property(f => f.GameDayNumber).IsRequired();

            builder.Property(f => f.HomeTeamName).HasMaxLength(255).IsRequired();

            builder.Property(f => f.AwayTeamName).HasMaxLength(255).IsRequired();

            builder.Property(f => f.HalfFieldLength).HasDefaultValue(100).IsRequired();

            builder.Property(f => f.ActionsPerMinute).HasDefaultValue(4).IsRequired();

            builder.Property(f => f.MaxOvertime).HasDefaultValue(8).IsRequired();

            builder.Property(f => f.ShotAccuracyModifier).HasDefaultValue(1).IsRequired();

            builder.Property(f => f.PaceModifier).HasDefaultValue(1).IsRequired();

            builder.Property(f => f.MaxHomeAdvantage).HasDefaultValue(0).IsRequired();

            builder.Property(f => f.MaxAwayDisadvantage).HasDefaultValue(0).IsRequired();
        }
    }
}
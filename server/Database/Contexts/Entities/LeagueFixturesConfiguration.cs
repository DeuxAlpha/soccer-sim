using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class LeagueFixturesConfiguration : IEntityTypeConfiguration<LeagueFixture>
    {
        public void Configure(EntityTypeBuilder<LeagueFixture> builder)
        {
            builder.HasKey(f => new {f.LeagueName, f.Season, f.GameDayNumber, f.HomeTeamName, f.AwayTeamName});

            builder.HasOne(f => f.League)
                .WithMany(l => l.LeagueFixtures)
                .HasForeignKey(f => new {f.LeagueName, f.Season})
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(f => f.GameDay)
                .WithMany(d => d.Fixtures)
                .HasForeignKey(f => new {f.LeagueName, f.Season, f.GameDayNumber})
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(f => f.HomeTeam)
                .WithMany(t => t.HomeLeagueFixtures)
                .HasForeignKey(f => new {f.HomeTeamName, f.Season})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(f => f.AwayTeam)
                .WithMany(t => t.AwayLeagueFixtures)
                .HasForeignKey(f => new {f.AwayTeamName, f.Season})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Property(f => f.LeagueName).HasMaxLength(255).IsRequired();

            builder.Property(f => f.Season).HasMaxLength(10).IsRequired();

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
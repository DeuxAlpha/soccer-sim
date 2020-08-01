using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class LeagueFixtureEventsConfiguration : IEntityTypeConfiguration<LeagueFixtureEvent>
    {
        public void Configure(EntityTypeBuilder<LeagueFixtureEvent> builder)
        {
            builder.HasKey(e => new
                {e.LeagueName, e.Season, e.GameDayNumber, e.HomeTeamName, e.AwayTeamName, e.Minute, e.AddedMinute});

            builder.HasOne(e => e.EventTeam)
                .WithMany(t => t.LeagueFixtureEvents)
                .HasForeignKey(e => new {e.EventTeamName, e.Season})
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(e => e.LeagueFixture)
                .WithMany(f => f.Events)
                .HasForeignKey(e => new {e.LeagueName, e.Season, e.GameDayNumber, e.HomeTeamName, e.AwayTeamName})
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Property(e => e.LeagueName).HasMaxLength(255).IsRequired();

            builder.Property(e => e.Season).HasMaxLength(10).IsRequired();

            builder.Property(e => e.GameDayNumber).IsRequired();

            builder.Property(e => e.HomeTeamName).HasMaxLength(255).IsRequired();

            builder.Property(e => e.AwayTeamName).HasMaxLength(255).IsRequired();

            builder.Property(e => e.EventTeamName).HasMaxLength(255).IsRequired();
        }
    }
}
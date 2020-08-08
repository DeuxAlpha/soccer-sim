using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class CompetitionFixtureEventsConfiguration : IEntityTypeConfiguration<CompetitionRoundFixtureEvent>
    {
        public void Configure(EntityTypeBuilder<CompetitionRoundFixtureEvent> builder)
        {
            builder.HasKey(e => new
            {
                e.CompetitionName,
                e.Season,
                e.RoundNumber,
                e.GameDayNumber,
                e.HomeTeamName,
                e.AwayTeamName,
                e.Minute,
                e.AddedMinute
            });

            builder.HasOne(e => e.EventTeam)
                .WithMany(t => t.CompetitionFixtureEvents)
                .HasForeignKey(e => new {e.EventTeamName, e.Season})
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(e => e.Fixture)
                .WithMany(f => f.Events)
                .HasForeignKey(e => new
                {
                    e.CompetitionName,
                    e.Season,
                    e.RoundNumber,
                    e.GameDayNumber,
                    e.HomeTeamName,
                    e.AwayTeamName
                })
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Property(e => e.CompetitionName).HasMaxLength(255).IsRequired();

            builder.Property(e => e.Season).HasMaxLength(10).IsRequired();

            builder.Property(e => e.RoundNumber).IsRequired();

            builder.Property(e => e.GroupName).HasMaxLength(100).IsRequired();

            builder.Property(e => e.GameDayNumber).IsRequired();

            builder.Property(e => e.HomeTeamName).HasMaxLength(255).IsRequired();

            builder.Property(e => e.AwayTeamName).HasMaxLength(255).IsRequired();
        }
    }
}
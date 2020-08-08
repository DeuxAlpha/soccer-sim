using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class CompetitionGameDaysConfiguration : IEntityTypeConfiguration<CompetitionRoundGameDay>
    {
        public void Configure(EntityTypeBuilder<CompetitionRoundGameDay> builder)
        {
            builder.HasKey(gd => new
            {
                gd.CompetitionName, gd.Season, gd.RoundNumber, gd.GroupName, gd.GameDayNumber
            });

            builder.HasOne(gd => gd.Group)
                .WithMany(r => r.GameDays)
                .HasForeignKey(gd => new {gd.CompetitionName, gd.Season, gd.RoundNumber, gd.GroupName})
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Property(gd => gd.Season).HasMaxLength(10).IsRequired();

            builder.Property(gd => gd.CompetitionName).HasMaxLength(255).IsRequired();

            builder.Property(gd => gd.RoundNumber).IsRequired();

            builder.Property(gd => gd.GroupName).HasMaxLength(100).IsRequired();

            builder.Property(gd => gd.GameDayNumber).IsRequired();
        }
    }
}
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class CompetitionGroupsConfiguration : IEntityTypeConfiguration<CompetitionRoundGroup>
    {
        public void Configure(EntityTypeBuilder<CompetitionRoundGroup> builder)
        {
            builder.HasKey(g => new {g.CompetitionName, g.Season, g.RoundNumber, g.GroupName});

            builder.HasOne(g => g.Round)
                .WithMany(r => r.Groups)
                .HasForeignKey(g => new {g.CompetitionName, g.Season, g.RoundNumber})
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Property(g => g.Season).HasMaxLength(10).IsRequired();

            builder.Property(g => g.CompetitionName).HasMaxLength(255).IsRequired();

            builder.Property(g => g.RoundNumber).IsRequired();

            builder.Property(g => g.GroupName).HasMaxLength(100).IsRequired();

            builder.Property(g => g.Rounds).IsRequired();
        }
    }
}
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class TeamCompetitionsConfiguration : IEntityTypeConfiguration<TeamCompetition>
    {
        public void Configure(EntityTypeBuilder<TeamCompetition> builder)
        {
            builder.HasKey(c => new {c.Year, c.TeamName, c.CompetitionName});

            builder.HasOne(c => c.Team)
                .WithMany(t => t.Competitions)
                .HasForeignKey(c => new {c.TeamName, c.Year})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(c => c.Competition)
                .WithMany(c => c.Teams)
                .HasForeignKey(c => new {c.CompetitionName, c.Year})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Property(c => c.Year).HasMaxLength(4).IsRequired();

            builder.Property(c => c.TeamName).HasMaxLength(255).IsRequired();

            builder.Property(c => c.CompetitionName).HasMaxLength(255).IsRequired();
        }
    }
}
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class CompetitionsConfiguration : IEntityTypeConfiguration<Competition>
    {
        public void Configure(EntityTypeBuilder<Competition> builder)
        {
            builder.HasKey(c => new {c.Name, c.Season});

            builder.HasOne(c => c.Continent)
                .WithMany(c => c.Competitions)
                .HasForeignKey(c => new {c.ContinentName, c.Season})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne(c => c.Country)
                .WithMany(c => c.Competitions)
                .HasForeignKey(c => new {c.CountryName, c.Season})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne(c => c.Division)
                .WithMany(d => d.Competitions)
                .HasForeignKey(c => new {c.DivisionName, c.Season})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne(c => c.League)
                .WithMany(l => l.Competitions)
                .HasForeignKey(c => new {c.LeagueName, c.Season})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.Property(c => c.Season).HasMaxLength(10).IsRequired();

            builder.Property(c => c.Name).HasMaxLength(255).IsRequired();

            builder.Property(c => c.Abbreviation).HasMaxLength(10);

            builder.Property(c => c.CompetitionType).HasConversion<string>().HasMaxLength(100).IsRequired();

            builder.Property(c => c.TournamentOnNeutralGrounds).HasDefaultValue(false).IsRequired();

            builder.Property(c => c.ContinentName).HasMaxLength(255);

            builder.Property(c => c.CountryName).HasMaxLength(255);

            builder.Property(c => c.DivisionName).HasMaxLength(255);

            builder.Property(c => c.LeagueName).HasMaxLength(255);
        }
    }
}
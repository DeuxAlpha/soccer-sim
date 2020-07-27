using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class DivisionsConfiguration : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder.HasKey(d => new {d.Name, d.Year});

            builder.HasOne(d => d.Country)
                .WithMany(c => c.Divisions)
                .HasForeignKey(d => new {d.CountryName, d.Year})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Property(d => d.Name).HasMaxLength(255).IsRequired();

            builder.Property(d => d.Year).HasMaxLength(4).IsRequired();

            builder.Property(d => d.Abbreviation).HasMaxLength(10);

            builder.Property(d => d.Level).HasDefaultValue(1).IsRequired();
        }
    }
}
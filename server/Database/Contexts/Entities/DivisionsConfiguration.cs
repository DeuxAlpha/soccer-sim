using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class DivisionsConfiguration : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder.HasKey(d => new {d.Name, d.Season});

            builder.HasOne(d => d.Country)
                .WithMany(c => c.Divisions)
                .HasForeignKey(d => new {d.CountryName, d.Season})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Property(d => d.Name).HasMaxLength(255).IsRequired();

            builder.Property(d => d.Season).HasMaxLength(10).IsRequired();

            builder.Property(d => d.Abbreviation).HasMaxLength(10);

            builder.Property(d => d.Level).HasDefaultValue(1).IsRequired();
        }
    }
}
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class ContinentsConfiguration : IEntityTypeConfiguration<Continent>
    {
        public void Configure(EntityTypeBuilder<Continent> builder)
        {
            builder.HasKey(c => new {c.Name, c.Season});

            builder.Property(c => c.Season).HasMaxLength(10).IsRequired();

            builder.Property(c => c.Name).HasMaxLength(255).IsRequired();
        }
    }
}
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Contexts.Entities
{
    public class PromotionSystemsConfiguration : IEntityTypeConfiguration<PromotionSystem>
    {
        public void Configure(EntityTypeBuilder<PromotionSystem> builder)
        {
            builder.HasKey(s => new {s.LeagueName, s.Season});

            builder.HasOne(s => s.League)
                .WithOne(l => l.PromotionSystem)
                .HasForeignKey<PromotionSystem>(s => new {s.LeagueName, s.Season})
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(s => s.LeagueName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(s => s.Season)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
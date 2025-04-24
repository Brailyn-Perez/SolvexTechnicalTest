using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolvexTechnicalTest.Core.Domain.Entities;

namespace SolvexTechnicalTest.Infraestructure.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .HasMaxLength(250);

            builder.Property(p => p.ImageUrl)
                .HasMaxLength(250);

            builder.Property(p => p.ColorId)
                .IsRequired(false);

            builder.HasOne(p => p.Color)
                .WithMany()
                .HasForeignKey(p => p.ColorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

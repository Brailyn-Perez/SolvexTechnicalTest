using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolvexTechnicalTest.Core.Domain.Entities;

namespace SolvexTechnicalTest.Infraestructure.Persistence.Configuration
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Colors");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.HexCode)
                .IsRequired()
                .HasMaxLength(7);

            builder.HasIndex(c => c.HexCode)
                .IsUnique()
                .HasDatabaseName("IX_Colors_Name");

            builder.Property(c => c.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasMany(c => c.Products)
                .WithOne(p => p.Color)
                .HasForeignKey(p => p.ColorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

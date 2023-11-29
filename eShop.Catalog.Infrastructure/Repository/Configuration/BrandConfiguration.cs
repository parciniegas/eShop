using eShop.Catalog.Domain.Brands;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Catalog.Infrastructure.Repository.Configuration;

public class BrandConfiguration: IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever();
        builder.HasIndex(p => p.Name)
            .IsUnique();
        builder.Property(b => b.Name)
            .HasMaxLength(Constants.MaxNameLength)
            .IsRequired();
        builder.Property(b => b.Description)
            .HasMaxLength(Constants.MaxDescriptionLength)
            .IsRequired(false);
    }
}
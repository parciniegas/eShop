using eShop.Catalog.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Catalog.Infrastructure.Repository.Configuration;

public class ProductConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever();
        builder.HasIndex(p => p.Name)
            .IsUnique();
        builder.Property(p => p.Name)
            .HasMaxLength(Constants.MaxNameLength)
            .IsRequired();
        builder.Property(p => p.Description)
            .HasMaxLength(Constants.MaxDescriptionLength)
            .IsRequired(false);
        builder.Property(p => p.AvailableStock)
            .IsRequired();
        builder.Property(p => p.RestockThreshold)
            .IsRequired();
        builder.OwnsMany(p => p.Tags, t =>
        {
            t.WithOwner().HasForeignKey("ProductId");
            t.Property<int>("Id");
            t.HasKey("Id");
        });
        builder.OwnsMany(p => p.Reviews, r =>
        {
            r.WithOwner();
        });
    }
}
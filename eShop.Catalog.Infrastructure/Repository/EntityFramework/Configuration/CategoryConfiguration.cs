using eShop.Catalog.Domain.Categories;
using eShop.Catalog.Domain.CategoriesProducts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Catalog.Infrastructure.Repository.EntityFramework.Configuration;

public class CategoryConfiguration: IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever();
        builder.HasIndex(p => p.Name);
        builder.Property(c => c.Name)
            .HasMaxLength(Constants.MaxNameLength)
            .IsRequired();
        builder.Property(c => c.Description)
            .HasMaxLength(Constants.MaxDescriptionLength)
            .IsRequired(false);
        builder.HasMany(c => c.Products)
            .WithMany(p => p.Categories)
            .UsingEntity<CategoryProduct>();
    }
}
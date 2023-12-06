using eShop.Catalog.Domain.Brands;
using eShop.Catalog.Domain.Categories;
using eShop.Catalog.Domain.Products;
using Ilse.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.Infrastructure.Repository.EntityFramework;

public class CatalogContext: BaseContext
{
    public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
    { }

    public required DbSet<Brand> Brands { get; set; }
    public required DbSet<Product> Products { get; set; }
    public required DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
    }
}
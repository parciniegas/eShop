using eShop.Catalog.Domain.Products;
using Ilse.Repository.Abstracts;

namespace eShop.Catalog.Domain.Categories;

public class Category: AuditedEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
}

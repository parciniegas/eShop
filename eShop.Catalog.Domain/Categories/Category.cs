using eShop.Catalog.Domain.Products;
using Ilse.Repository.Abstracts;

namespace eShop.Catalog.Domain.Categories;

public class Category(int id, string? name, string? description) : AuditedEntity
{
    public int Id { get; init; } = id;
    public string? Name { get; set; } = name;
    public string? Description { get; set; } = description;

    public List<Product> Products { get; init; } = [];
}

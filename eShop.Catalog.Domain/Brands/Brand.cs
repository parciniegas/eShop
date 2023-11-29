using Ilse.Repository.Abstracts;

namespace eShop.Catalog.Domain.Brands;

public class Brand: AuditedEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}

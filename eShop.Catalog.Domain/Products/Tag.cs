using System.ComponentModel.DataAnnotations;

namespace eShop.Catalog.Domain.Products;

public class Tag
{
    [MaxLength(50)]
    public required string Name { get; set; }
    [MaxLength(250)]
    public required string Value { get; set; }
}

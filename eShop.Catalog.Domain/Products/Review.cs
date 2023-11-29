using System.ComponentModel.DataAnnotations;

namespace eShop.Catalog.Domain.Products;

public class Review
{
    public DateTime Date { get; set; }
    [MaxLength(5000)]
    public required string Notes { get; set; }
}

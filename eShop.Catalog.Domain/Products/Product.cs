using System.ComponentModel.DataAnnotations;
using eShop.Catalog.Domain.Brands;
using eShop.Catalog.Domain.Categories;
using Ilse.Repository.Abstracts;

namespace eShop.Catalog.Domain.Products;

public class Product: AuditedEntity
{
    public Product(string id, string name, string description, int brandId, 
        decimal price, int availableStock, int restockThreshold)
    {
        Id = id;
        Name = name;
        Description = description;
        BrandId = brandId;
        Price = price;
        AvailableStock = availableStock;
        RestockThreshold = restockThreshold;
    }
    [MaxLength(Constants.MaxIdLength)]
    public string Id { get; set; }
    [MaxLength(Constants.MaxNameLength)]
    public string Name { get; set; }
    [MaxLength(Constants.MaxDescriptionLength)]
    public string Description { get; set; }
    public int BrandId { get; set; }
    public virtual Brand? Brand { get; set; }
    public decimal Price { get; set; }
    public int AvailableStock { get; set; }
    public int RestockThreshold { get; set; }
    public List<Category> Categories { get; set; } = new();
    public List<Tag> Tags { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
    public List<string> Labels { get; set; } = new();
}

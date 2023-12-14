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
    public string Id { get; init; }
    [MaxLength(Constants.MaxNameLength)]
    private string _name = string.Empty;
    public string Name { get => _name; 
        set => SetField(ref _name, value); }
    [MaxLength(Constants.MaxDescriptionLength)]
    public string Description { get; set; }
    private int _brandId;
    public int BrandId { get => _brandId; 
        set => SetField(ref _brandId, value); }
    public virtual Brand? Brand { get; set; }
    private decimal _price;
    public decimal Price { get => _price; 
        set => SetField(ref _price, value); }
    public int AvailableStock { get; set; }
    public int RestockThreshold { get; set; }
    public List<Category> Categories { get; init; } = [];
    public List<Tag> Tags { get; init; } = [];
    public List<Review> Reviews { get; init; } = [];
    public List<string> Labels { get; init; } = [];
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using eShop.Catalog.Domain.Brands;
using eShop.Catalog.Domain.Categories;
using Ilse.Repository.Abstracts;

namespace eShop.Catalog.Domain.Products;

public class Product: AuditedEntity, INotifyPropertyChanged
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
    private string _name = string.Empty;
    public string Name { get => _name; 
        set => SetField(ref _name, value); }
    [MaxLength(Constants.MaxDescriptionLength)]
    public string Description { get; set; }
    private int _brandId;
    public int BrandId { get => _brandId; 
        set => SetField(ref _brandId, value); }
    public virtual Brand? Brand { get; set; }
    public decimal Price { get; set; }
    public int AvailableStock { get; set; }
    public int RestockThreshold { get; set; }
    public List<Category> Categories { get; set; } = new();
    public List<Tag> Tags { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
    public List<string> Labels { get; set; } = new();
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}

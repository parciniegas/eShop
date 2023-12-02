namespace eShop.Catalog.Domain.Baskets;

public class BasketItem(string productId, string productName, int quantity, decimal unitPrice)
{
    public string ProductId { get; set; } = productId;
    public string ProductName { get; set; } = productName;
    public int Quantity { get; set; } = quantity;
    public decimal UnitPrice { get; set; } = unitPrice;
    public decimal Total => Quantity*UnitPrice;
}
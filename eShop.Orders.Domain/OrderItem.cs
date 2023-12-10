namespace eShop.Orders.Domain;

public class OrderItem(string productId, int units, decimal unitPrice, string productName)
{
    public string ProductId { get; set; } = productId;
    public string ProductName { get; set; } = productName;
    public int Units { get; set; } = units;
    public decimal UnitPrice { get; set; } = unitPrice;
    public decimal Total => UnitPrice*Units;
}
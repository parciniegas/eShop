namespace eShop.Catalog.Domain.Baskets;

public class Basket(string buyerId)
{
    public string BuyerId { get; set; } = buyerId;
    public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    public decimal Total => BasketItems.Sum(bi => bi.Total);
}
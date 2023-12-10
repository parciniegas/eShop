namespace eShop.Basket.Domain.Cart;

public class Basket(string buyerId)
{
    public string BuyerId { get; init; } = buyerId;
    public List<BasketItem> BasketItems { get; init; } = [];
    public decimal Total => BasketItems.Sum(bi => bi.Total);
}
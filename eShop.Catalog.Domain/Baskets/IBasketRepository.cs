namespace eShop.Catalog.Domain.Baskets;

public interface IBasketRepository
{
    public Task<Basket?> GetBasketAsync(string buyerId, CancellationToken cancellationToken = default);
    public Task AddBasketAsync(Basket basket, CancellationToken cancellationToken = default);
    public Task UpdateBasketAsync(Basket basket, CancellationToken cancellationToken = default);
    public Task<bool> DeleteBasketAsync(string buyerId, CancellationToken cancellationToken = default);
}
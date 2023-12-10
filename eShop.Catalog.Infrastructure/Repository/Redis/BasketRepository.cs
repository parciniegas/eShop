using System.Text.Json;
using eShop.Catalog.Domain.Baskets;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace eShop.Catalog.Infrastructure.Repository.Redis;

public sealed class BasketRepository: IBasketRepository, IDisposable, IAsyncDisposable
{
    private readonly ConnectionMultiplexer _redis;
    public BasketRepository(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Redis");
        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentException("Redis connection string not found!");
        _redis = ConnectionMultiplexer.Connect(connectionString);
    }
    public async Task<Basket?> GetBasketAsync(string buyerId, CancellationToken cancellationToken = default)
    {
        var basket = await _redis.GetDatabase().StringGetAsync(buyerId);
        return basket.IsNullOrEmpty 
            ? null 
            : JsonSerializer.Deserialize<Basket>(basket!);
    }

    public async Task AddBasketAsync(Basket basket, CancellationToken cancellationToken = default)
    {
        await _redis.GetDatabase().StringSetAsync(basket.BuyerId, JsonSerializer.Serialize(basket));
    }

    public async Task UpdateBasketAsync(Basket basket, CancellationToken cancellationToken = default)
    {
        await _redis.GetDatabase().StringSetAsync(basket.BuyerId, JsonSerializer.Serialize(basket));
    }

    public async Task<bool> DeleteBasketAsync(string buyerId, CancellationToken cancellationToken = default)
    {
        return await _redis.GetDatabase().KeyDeleteAsync(buyerId);
    }

    public void Dispose()
    {
        _redis.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _redis.DisposeAsync();
    }
}
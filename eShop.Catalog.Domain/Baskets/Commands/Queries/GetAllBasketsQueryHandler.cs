using Ilse.Cqrs.Queries;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Baskets.Commands.Queries;

public class GetAllBasketsQueryHandler(
    IRepository repository): IQueryHandler<List<Basket>>
{
    public async Task<List<Basket>> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var baskets = await repository.GetAllAsync<Basket>(cancellationToken);
        return baskets.ToList();
    }
}
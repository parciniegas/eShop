using eShop.Catalog.Domain.Exceptions;
using Ilse.Cqrs.Queries;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Brands.Queries.GetByName;

public class GetBrandByNameQueryHandler(IRepository repository)
    : IQueryHandler<GetBrandByNameQuery, Brand>
{
    public async Task<Brand> HandleAsync(GetBrandByNameQuery query, 
        CancellationToken cancellationToken = default)
    {
        var brands = 
            await repository.GetByAsync<Brand>(b => b.Name == query.Name, cancellationToken);
        var brand = brands.FirstOrDefault();
        return brand ?? throw new EntityNotFoundException($"Brand with name '{query.Name}' not found");
    }
}
using eShop.Common.Exceptions;
using Ilse.Cqrs.Queries;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Brands.Queries.GetById;

public class GetBrandByIdQueryHandler(IRepository repository) 
    : IQueryHandler<GetBrandByIdQuery, Brand>
{
    public async Task<Brand> HandleAsync(GetBrandByIdQuery query, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        var brand = await repository.GetByIdAsync<Brand, int>(query.Id, cancellationToken);
        if (brand == null)
            throw new EntityNotFoundException($"Brand with id '{query.Id}' not found");
        return brand;
    }
}
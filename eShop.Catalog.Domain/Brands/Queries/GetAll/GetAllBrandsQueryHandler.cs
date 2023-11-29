using Ilse.Cqrs.Queries;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Brands.Queries.GetAll;

public class GetAllBrandsQueryHandler(IRepository repository) 
    : IQueryHandler<GetAllBrandsQueryResult>
{
    public async Task<GetAllBrandsQueryResult> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var brands = new GetAllBrandsQueryResult(
            (await repository.GetAllAsync<Brand>(cancellationToken)).ToList());
        return brands;
    }
}
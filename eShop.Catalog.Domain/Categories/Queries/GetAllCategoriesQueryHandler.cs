using Ilse.Cqrs.Queries;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Categories.Queries;

public class GetAllCategoriesQueryHandler(
    IRepository repository): IQueryHandler<List<Category>>
{
    public async Task<List<Category>> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return (await repository.GetAllAsync<Category>(cancellationToken)).ToList();
    }
}
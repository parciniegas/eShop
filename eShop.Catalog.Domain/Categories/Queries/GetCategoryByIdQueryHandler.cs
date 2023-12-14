using eShop.Common.Exceptions;
using Ilse.Cqrs.Queries;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Categories.Queries;

public class GetCategoryByIdQueryHandler(
    IRepository repository): IQueryHandler<GetCategoryByIdQuery, Category>
{
    public async Task<Category> HandleAsync(GetCategoryByIdQuery query, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        var category = await repository.GetByIdAsync<Category, int>(query.Id, cancellationToken);
        if (category == null)
            throw new EntityNotFoundException($"Category with id '{query.Id}' not found");
        return category;
    }
}
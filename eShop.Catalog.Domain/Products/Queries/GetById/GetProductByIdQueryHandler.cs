using eShop.Catalog.Domain.Exceptions;
using Ilse.Cqrs.Queries;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Products.Queries.GetById;

public class GetProductByIdQueryHandler(
    IRepository repository): IQueryHandler<GetProductByIdQuery, Product>
{
    public async Task<Product> HandleAsync(GetProductByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var product = 
            (await repository.GetByAsync<Product>(p => p.Id == query.Id, cancellationToken))
            .Select(p => new Product(p.Id, p.Name, p.Description, p.BrandId, p.Price, p.AvailableStock, p.RestockThreshold)
            {
                Tags = p.Tags,
                Labels = p.Labels,
                Reviews = p.Reviews,
                Categories = p.Categories
            })
            .FirstOrDefault();
        if (product == null)
            throw new EntityNotFoundException($"Product with id '{query.Id}' not found!");
        return product;
    }
}
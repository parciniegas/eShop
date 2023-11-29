using Ilse.Cqrs.Queries;

namespace eShop.Catalog.Application.Products.Queries.GetById;

public record AppGetProductByIdQuery(string Id): IQuery;
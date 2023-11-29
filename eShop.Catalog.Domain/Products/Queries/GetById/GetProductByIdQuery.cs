using Ilse.Cqrs.Queries;

namespace eShop.Catalog.Domain.Products.Queries.GetById;

// ReSharper disable once ClassNeverInstantiated.Global
public record GetProductByIdQuery(string Id): IQuery;
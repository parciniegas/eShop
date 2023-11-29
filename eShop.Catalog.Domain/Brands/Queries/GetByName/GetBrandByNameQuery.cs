using Ilse.Cqrs.Queries;

namespace eShop.Catalog.Domain.Brands.Queries.GetByName;

public record GetBrandByNameQuery(string Name): IQuery;
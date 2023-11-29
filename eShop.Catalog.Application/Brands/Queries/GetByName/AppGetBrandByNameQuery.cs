using Ilse.Cqrs.Queries;

namespace eShop.Catalog.Application.Brands.Queries.GetByName;

public record AppGetBrandByNameQuery(string Name): IQuery;
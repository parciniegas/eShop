using Ilse.Cqrs.Queries;

namespace eShop.Catalog.Domain.Brands.Queries.GetById;

public record GetBrandByIdQuery(int Id) : IQuery;
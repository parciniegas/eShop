using Ilse.Cqrs.Queries;

namespace eShop.Catalog.Application.Brands.Queries.GetById;
// ReSharper disable once ClassNeverInstantiated.Global
public record AppGetBrandByIdQuery(int Id): IQuery;

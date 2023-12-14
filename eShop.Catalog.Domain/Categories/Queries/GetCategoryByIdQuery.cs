using Ilse.Cqrs.Queries;

namespace eShop.Catalog.Domain.Categories.Queries;

public record GetCategoryByIdQuery(int Id): IQuery;
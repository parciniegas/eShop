using eShop.Catalog.Domain.Products;
using Microsoft.AspNetCore.JsonPatch;

namespace eShop.Catalog.API.Endpoints.Products.Update;

public record UpdateProductRequest(JsonPatchDocument<Product> Request);
using FluentValidation;

namespace eShop.Catalog.API.Endpoints.Products.Add;

public class AddProductRequestValidator: AbstractValidator<AddProductRequest>
{
    public AddProductRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().MaximumLength(Domain.Products.Constants.MaxIdLength);
        RuleFor(x => x.Name)
            .NotEmpty().MaximumLength(Domain.Products.Constants.MaxNameLength);
        RuleFor(x => x.Description)
            .NotEmpty().MaximumLength(Domain.Products.Constants.MaxDescriptionLength);
        RuleFor(x => x.BrandId)
            .NotEmpty();
        RuleFor(x => x.Price)
            .NotEmpty().GreaterThan(0);
        RuleFor(x => x.AvailableStock)
            .NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.RestockThreshold)
            .NotEmpty().GreaterThan(0);
    }
}
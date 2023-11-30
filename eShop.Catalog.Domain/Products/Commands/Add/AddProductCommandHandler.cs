using eShop.Catalog.Domain.Exceptions;
using Ilse.Cqrs.Commands;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Products.Commands.Add;

public class AddProductCommandHandler(
        IRepository repository)
    : ICommandHandler<AddProductCommand>
{
    public async Task HandleAsync(AddProductCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var product =
            (await repository.GetByAsync<Product>
                (p => p.Id == command.Id || p.Name == command.Name, cancellationToken))
            .FirstOrDefault();
        if (product != null)
            throw new EntityAlreadyExistsException(
                $"Product with id '{command.Id}' or name '{command.Name}' already exist!");
        product = new Product(
            command.Id,
            command.Name,
            command.Description,
            command.BrandId,
            command.Price,
            command.AvailableStock,
            command.RestockThreshold)
        {
            Labels = command.Labels,
            Tags = command.Tags.Select(t => new Tag { Name = t.Name, Value = t.Value }).ToList()
        };

        await repository.AddAsync(product, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }
}
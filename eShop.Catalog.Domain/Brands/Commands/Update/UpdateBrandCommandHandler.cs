using eShop.Catalog.Domain.Exceptions;
using Ilse.Cqrs.Commands;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Brands.Commands.Update;

public class UpdateBrandCommandHandler(IRepository repository)
    : ICommandHandler<UpdateBrandCommand>
{
    public async Task HandleAsync(UpdateBrandCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var brand = await repository.GetByIdAsync<Brand, int>(command.Id, cancellationToken) 
            ?? throw new EntityNotFoundException($"Brand with id '{command.Id}' not found");
        brand.Name = command.Name;
        brand.Description = command.Description;
        await repository.UpdateAsync(brand, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }
}
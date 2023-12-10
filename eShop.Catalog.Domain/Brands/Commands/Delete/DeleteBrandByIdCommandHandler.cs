using eShop.Common.Exceptions;
using Ilse.Cqrs.Commands;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Brands.Commands.Delete;

public class DeleteBrandByIdCommandHandler(IRepository repository): 
    ICommandHandler<DeleteBrandByIdCommand>
{
    public async Task HandleAsync(DeleteBrandByIdCommand command, 
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetByIdAsync<Brand, int>(command.Id, cancellationToken) 
            ?? throw new EntityNotFoundException($"Brand with id '{command.Id}' not found");
        await repository.DeleteAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }
}
using eShop.Catalog.Domain.Exceptions;
using Ilse.Cqrs.Commands;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Brands.Commands.Add;

public class AddBrandCommandHandler(IRepository repository) 
    : ICommandHandler<AddBrandCommand, AddBrandCommandResult>
{
    public async Task<AddBrandCommandResult> HandleAsync(AddBrandCommand command, CancellationToken cancellationToken = default)
    {
        var brandExists = 
            await repository.GetByAsync<Brand>(b => b.Name == command.Name, cancellationToken);
        if (brandExists.Any())
            throw new EntityAlreadyExistsException($"Brand with name '{command.Name}' already exists");

        var id = await repository.GetNextSequenceAsync<Brand>();
        var brand = new Brand{ Id = id, Name = command.Name, Description = command.Description};
        var response = await repository.AddAsync(brand, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return new AddBrandCommandResult(response.Id);
    }
}
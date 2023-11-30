using eShop.Catalog.Domain.Exceptions;
using Ilse.Cqrs.Commands;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Products.Commands.Update
{
    public class UpdateProductCommandHandler(
        IRepository repository): ICommandHandler<UpdateProductCommand>
    {
        public async Task HandleAsync(UpdateProductCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var product = (await repository.GetByAsync<Product>(p => p.Id == command.Id, cancellationToken))
                .FirstOrDefault() 
                ?? throw new EntityNotFoundException($"Product with id '{command.Id}' not found!");
            product.Name = command.Name;
            product.Description = command.Description;
            product.BrandId = command.BrandId;
            await repository.UpdateAsync(product, cancellationToken);
        }
    }
}

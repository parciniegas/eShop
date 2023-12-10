using System.ComponentModel;
using eShop.Catalog.Domain.Products.Events;
using eShop.Common.Exceptions;
using Ilse.Cqrs.Commands;
using Ilse.Events.Queue;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Products.Commands.Update
{
    public class UpdateProductCommandHandler(
        IRepository repository,
        IEventQueue eventQueue): ICommandHandler<UpdateProductCommand>
    {
        public async Task HandleAsync(UpdateProductCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var product = (await repository.GetByIdAsync<Product, string>(command.Id, cancellationToken))
                ?? throw new EntityNotFoundException($"Product with id '{command.Id}' not found!");
            product.PropertyChanged += PropertyChanged;
            product.Name = command.Name;
            product.Description = command.Description;
            product.BrandId = command.BrandId;
            await repository.UpdateAsync(product, cancellationToken);
            await repository.SaveChangesAsync(cancellationToken);
            product.PropertyChanged -= PropertyChanged;
        }

        private void PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Product.Name):
                    eventQueue.Enqueue(new ProductNameChangedEvent((sender as Product)!.Id, (sender as Product)!.Name));
                    break;
                case nameof(Product.BrandId):
                    eventQueue.Enqueue(new ProductBrandChangedEvent((sender as Product)!.Id, (sender as Product)!.BrandId));
                    break;
            }
        }
    }
}

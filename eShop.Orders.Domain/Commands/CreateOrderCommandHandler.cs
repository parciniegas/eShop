using Ilse.Cqrs.Commands;
using Ilse.Repository.Contracts;

namespace eShop.Orders.Domain.Commands;

public class CreateOrderCommandHandler(
    IRepository repository): ICommandHandler<CreateOrderCommand>
{
    public async Task HandleAsync(CreateOrderCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var order = new Order("", command.OrderDate,
            new Domain.Address(command.ShippingAddress.City, command.ShippingAddress.Street,
                command.ShippingAddress.Details),
            new Domain.Address(command.BillingAddress.City, command.BillingAddress.Street,
                command.BillingAddress.Details),
            new Domain.Customer(command.Customer.CustomerId, command.Customer.FirstName, command.Customer.LastName,
                command.Customer.Email, command.Customer.Phone));
        
        await repository.AddAsync(order, cancellationToken);
    }
}
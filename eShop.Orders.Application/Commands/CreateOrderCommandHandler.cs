using eShop.Orders.Domain.Commands;
using Ilse.Cqrs.Commands;

namespace eShop.Orders.Application.Commands;

public class CreateOrderCommandHandler(
    ICommandDispatcher dispatcher): ICommandHandler<AppCreateOrderCommand, string>
{
    public async Task<string> HandleAsync(AppCreateOrderCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var order = new CreateOrderCommand(command.OrderDate,
            new Domain.Commands.Address(command.ShippingAddress.City, command.ShippingAddress.Street,
                command.ShippingAddress.Details),
            new Domain.Commands.Address(command.BillingAddress.City, command.BillingAddress.Street,
                command.BillingAddress.Details),
            new Domain.Commands.Customer(command.Customer.CustomerId, command.Customer.FirstName,
                command.Customer.LastName,
                command.Customer.Email, command.Customer.Phone),
            command.Items.Select(i => new Domain.Commands.OrderItem(i.ProductId, i.ProductName, i.UnitPrice, i.Units))
                .ToList());

        var orderNumber = await dispatcher.ExecAsync<CreateOrderCommand, string>(order, cancellationToken);
        return orderNumber;
    }
}
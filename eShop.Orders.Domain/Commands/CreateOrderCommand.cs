using Ilse.Cqrs.Commands;

namespace eShop.Orders.Domain.Commands;

public record CreateOrderCommand(
    string OrderNumber,
    DateTime OrderDate,
    Address ShippingAddress,
    Address BillingAddress,
    Customer Customer,
    List<OrderItem> Items) : ICommand;

public record Address(string City, string Street, string Details);
public record Customer(string CustomerId, string FirstName, string LastName, string Email, string Phone);
public record OrderItem(string ProductId, string ProductName, decimal UnitPrice, int Units);
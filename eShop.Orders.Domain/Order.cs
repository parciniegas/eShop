namespace eShop.Orders.Domain;

public class Order(
    string orderNumber,
    DateTime orderDate,
    Address shippingAddress,
    Address billingAddress,
    Customer customer)
{
    public string OrderNumber { get; set; } = orderNumber;
    public DateTime OrderDate { get; set; } = orderDate;
    public List<OrderItem> Items { get; init; } = [];
    public decimal Total => Items.Sum(i => i.Total);
    public Address ShippingAddress { get; set; } = shippingAddress;
    public Address BillingAddress { get; set; } = billingAddress;
    public Customer Customer { get; set; } = customer;
}
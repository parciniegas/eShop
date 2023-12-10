namespace eShop.Orders.Domain;

public class Address(string city, string street, string details)
{
    public string City { get; set; } = city;
    public string Street { get; set; } = street;
    public string Details { get; set; } = details;
}
namespace eShop.Orders.Domain;

public class Customer(string customerId, string firstName, string lastName, string email, string phone)
{
    public string CustomerId { get; set; } = customerId;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string FullName { get => $"{FirstName} {LastName}";  }
    public string Email { get; set; } = email;
    public string Phone { get; set; } = phone;
}
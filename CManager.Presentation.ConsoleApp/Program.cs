using CManager.Presentation.ConsoleApp.Models;
using CManager.Presentation.ConsoleApp.Repositories;
using CManager.Presentation.ConsoleApp.Services;

var repository = new CustomerRepository();
var customerService = new CustomerService(repository);

while (true)
{
    Console.Clear();
    Console.WriteLine("=== CUSTOMER MANAGER ===");
    Console.WriteLine("1. Add customer");
    Console.WriteLine("2. Show all customers");
    Console.WriteLine("3. Show a specific customer");
    Console.WriteLine("4. Remove customer by email");
    Console.WriteLine("0. Exit");
    Console.Write("Choose: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddCustomer(customerService);
            break;

        case "2":
            ShowCustomers(customerService);
            break;

        case "3":
            ShowSpecificCustomer(customerService);
            break;

        case "4":
            RemoveCustomer(customerService);
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Invalid choice");
            Console.ReadKey();
            break;
    }
}

static void AddCustomer(CustomerService service)
{
    Console.Write("First name: ");
    var firstName = Console.ReadLine() ?? "";

    Console.Write("Last name: ");
    var lastName = Console.ReadLine() ?? "";

    Console.Write("Email: ");
    var email = Console.ReadLine() ?? "";

    Console.Write("Phone number: ");
    var phone = Console.ReadLine() ?? "";

    Console.Write("Street: ");
    var street = Console.ReadLine() ?? "";

    Console.Write("Postal code: ");
    var postalCode = Console.ReadLine() ?? "";

    Console.Write("City: ");
    var city = Console.ReadLine() ?? "";

    var address = new Address
    {
        Street = street,
        PostalCode = postalCode,
        City = city
    };

    service.CreateCustomer(firstName, lastName, email, phone, address);

    Console.WriteLine("Customer added!");
    Console.ReadKey();
}

static void ShowCustomers(CustomerService service)
{
    var customers = service.GetAllCustomers();

    Console.WriteLine();
    foreach (var customer in customers)
    {
        Console.WriteLine($"{customer.FirstName} {customer.LastName} - {customer.Email}");
    }

    Console.ReadKey();
}

static void ShowSpecificCustomer(CustomerService service)
{
    Console.Write("Enter email: ");
    var email = Console.ReadLine() ?? "";

    var customer = service.GetCustomerByEmail(email);

    if (customer == null)
    {
        Console.WriteLine("Customer not found");
        Console.ReadKey();
        return;
    }

    Console.WriteLine();
    Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");
    Console.WriteLine($"Id: {customer.Id}");
    Console.WriteLine($"Email: {customer.Email}");
    Console.WriteLine($"Phone: {customer.PhoneNumber}");
    Console.WriteLine($"Address: {customer.Address.Street}, {customer.Address.PostalCode} {customer.Address.City}");

    Console.ReadKey();
}

static void RemoveCustomer(CustomerService service)
{
    Console.Write("Email to remove: ");
    var email = Console.ReadLine() ?? "";

    var removed = service.RemoveCustomerByEmail(email);

    Console.WriteLine(removed ? "Customer removed" : "Customer not found");
    Console.ReadKey();
}


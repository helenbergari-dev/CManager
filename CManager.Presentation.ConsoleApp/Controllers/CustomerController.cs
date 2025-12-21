using System;
using System.Collections.Generic;
using CManager.Presentation.ConsoleApp.Interfaces;
using CManager.Presentation.ConsoleApp.Models;

namespace CManager.Presentation.ConsoleApp.Controllers
{
    public class CustomerController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== CUSTOMER MANAGER ===");
                Console.WriteLine("1. Skapa kund");
                Console.WriteLine("2. Visa alla kunder");
                Console.WriteLine("3. Visa specifik kund");
                Console.WriteLine("4. Ta bort kund");
                Console.WriteLine("0. Avsluta");
                Console.Write("Välj: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateCustomer();
                        break;

                    case "2":
                        ShowAllCustomers();
                        break;

                    case "3":
                        ShowSpecificCustomer();
                        break;

                    case "4":
                        RemoveCustomer();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Ogiltigt val!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void CreateCustomer()
        {
            Console.Clear();
            Console.WriteLine("=== Skapa kund ===");

            Console.Write("Förnamn: ");
            var firstName = Console.ReadLine() ?? "";

            Console.Write("Efternamn: ");
            var lastName = Console.ReadLine() ?? "";

            Console.Write("E-post: ");
            var email = Console.ReadLine() ?? "";

            Console.Write("Telefon: ");
            var phone = Console.ReadLine() ?? "";

            Console.Write("Gatuadress: ");
            var street = Console.ReadLine() ?? "";

            Console.Write("Postnummer: ");
            var postalCode = Console.ReadLine() ?? "";

            Console.Write("Ort: ");
            var city = Console.ReadLine() ?? "";

            var address = new Address
            {
                Street = street,
                PostalCode = postalCode,
                City = city
            };

            var created = _customerService.CreateCustomer(firstName, lastName, email, phone, address);

            Console.WriteLine();
            Console.WriteLine($"Kund skapad! Id: {created.Id}");
            Console.ReadKey();
        }

        private void ShowAllCustomers()
        {
            Console.Clear();
            Console.WriteLine("=== Alla kunder ===");

            var customers = _customerService.GetAllCustomers();

            if (customers.Count == 0)
            {
                Console.WriteLine("Inga kunder finns.");
            }
            else
            {
                foreach (var c in customers)
                {
                    Console.WriteLine($"{c.FirstName} {c.LastName} - {c.Email}");
                }
            }

            Console.ReadKey();
        }

        private void ShowSpecificCustomer()
        {
            Console.Clear();
            Console.WriteLine("=== Visa specifik kund ===");
            Console.Write("Ange e-post: ");
            var email = Console.ReadLine() ?? "";

            var customer = _customerService.GetCustomerByEmail(email);

            if (customer == null)
            {
                Console.WriteLine("Kunden hittades inte.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Namn: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"Id: {customer.Id}");
            Console.WriteLine($"E-post: {customer.Email}");
            Console.WriteLine($"Telefon: {customer.PhoneNumber}");
            Console.WriteLine($"Adress: {customer.Address.Street}, {customer.Address.PostalCode} {customer.Address.City}");

            Console.ReadKey();
        }

        private void RemoveCustomer()
        {
            Console.Clear();
            Console.WriteLine("=== Ta bort kund ===");
            Console.Write("Ange e-post: ");
            var email = Console.ReadLine() ?? "";

            var removed = _customerService.RemoveCustomerByEmail(email);

            Console.WriteLine();
            Console.WriteLine(removed ? "Kunden togs bort." : "Kunden hittades inte.");

            Console.ReadKey();
        }
    }
}

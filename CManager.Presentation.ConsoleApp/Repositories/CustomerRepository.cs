using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CManager.Presentation.ConsoleApp.Interfaces;
using CManager.Presentation.ConsoleApp.Models;

namespace CManager.Presentation.ConsoleApp.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _filePath = "customers.json";

        public void SaveCustomers(List<Customer> customers)
        {
            var json = JsonSerializer.Serialize(customers, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_filePath, json);
        }

        public List<Customer> LoadCustomers()
        {
            if (!File.Exists(_filePath))
                return new List<Customer>();

            var json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
                return new List<Customer>();

            var customers = JsonSerializer.Deserialize<List<Customer>>(json);

            return customers ?? new List<Customer>();
        }
    }
}


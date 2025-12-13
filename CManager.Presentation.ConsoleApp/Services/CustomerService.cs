using System;
using System.Collections.Generic;
using System.Linq;
using CManager.Presentation.ConsoleApp.Interfaces;
using CManager.Presentation.ConsoleApp.Models;

namespace CManager.Presentation.ConsoleApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly List<Customer> _customers;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
            _customers = _repository.LoadCustomers();
        }

        public Customer CreateCustomer(string firstName, string lastName, string email, string phoneNumber, Address address)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address
            };

            _customers.Add(customer);
            _repository.SaveCustomers(_customers);

            return customer;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public Customer? GetCustomerByEmail(string email)
        {
            return _customers.FirstOrDefault(c =>
                c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public bool RemoveCustomerByEmail(string email)
        {
            var customer = GetCustomerByEmail(email);

            if (customer == null)
                return false;

            _customers.Remove(customer);
            _repository.SaveCustomers(_customers);

            return true;
        }
    }
}


    


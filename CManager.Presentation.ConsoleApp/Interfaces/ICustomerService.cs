using CManager.Presentation.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CManager.Presentation.ConsoleApp.Interfaces
{
    public interface ICustomerService
    {
        Customer CreateCustomer(
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            Address address);
        List<Customer> GetAllCustomers();

        Customer? GetCustomerByEmail(string email);

        bool RemoveCustomerByEmail(string email);


    }
}

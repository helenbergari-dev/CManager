using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CManager.Presentation.ConsoleApp.Models;


namespace CManager.Presentation.ConsoleApp.Interfaces
{
    public interface ICustomerRepository
    {
        void SaveCustomers(List<Customer> customers);

        List<Customer> LoadCustomers(); 
    }
}

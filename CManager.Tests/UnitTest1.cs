using System;
using System.Collections.Generic;
using Moq;
using Xunit;

using CManager.Presentation.ConsoleApp.Interfaces;
using CManager.Presentation.ConsoleApp.Models;
using CManager.Presentation.ConsoleApp.Services;

namespace CManager.Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public void CreateCustomer_ShouldCreateCustomerWithGuidAndSave()
        {
            
            var repoMock = new Mock<ICustomerRepository>();

           
            repoMock.Setup(r => r.LoadCustomers())
                    .Returns(new List<Customer>());

            
            var service = new CustomerService(repoMock.Object);

            var address = new Address
            {
                Street = "Testgatan 1",
                PostalCode = "12345",
                City = "Teststad"
            };

          
            var created = service.CreateCustomer(
                "Stina",
                "Larsson",
                "stina@test.se",
                "0701234567",
                address
            );

            Assert.NotEqual(Guid.Empty, created.Id);

         
            Assert.Equal("Stina", created.FirstName);
            Assert.Equal("Larsson", created.LastName);
            Assert.Equal("stina@test.se", created.Email);

            repoMock.Verify(r => r.SaveCustomers(It.IsAny<List<Customer>>()), Times.AtLeastOnce);
        }
    }
}
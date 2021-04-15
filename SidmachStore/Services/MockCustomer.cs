

using SidmachStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SidmachStore.Services
{
    public class MockCustomer : ICustomer

    {

        private List<Customer> customers = new List<Customer>()
        {
                new Customer()
                {
                     Id = Guid.NewGuid(),
                     Name = "customer 1"
                },

                 new Customer()
                {
                     Id = Guid.NewGuid(),
                     Name = "customer 2"
                },

                 new Customer()
                {
                    Id = Guid.NewGuid(),
                    Name = "customer 3"
                }
        };
        public Customer AddCustomer(Customer customer)
        {
            customer.Id = Guid.NewGuid();
            customers.Add(customer);
            return customer;
        }

        public void DeleteCustomer(Customer customer)
        {
            customers.Remove(customer);
        }


        public Customer EditCustomer(Customer customer)
        {
           var existingCustomer = GetCustomer(customer.Id);
            existingCustomer.Name = customer.Name;
            return existingCustomer;

        }

        public Customer GetCustomer(Guid id)
        {
            return customers.SingleOrDefault(x => x.Id == id);
        }

        public List<Customer> GetCustomers()
        {
            return customers;
        }
    }
}

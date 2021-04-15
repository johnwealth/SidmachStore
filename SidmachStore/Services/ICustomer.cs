using SidmachStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SidmachStore.Services
{
    public interface ICustomer
    {
        List<Customer> GetCustomers();

        Customer GetCustomer(Guid Id);


        Customer AddCustomer(Customer customer);


        void DeleteCustomer(Customer customer);


        Customer EditCustomer(Customer customer);
        

    }
}

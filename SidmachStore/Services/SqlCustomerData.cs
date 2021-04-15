using SidmachStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SidmachStore.Services
{
    public class SqlCustomerData : ICustomer
    {
        private CustomerContext _customerContext;
        public SqlCustomerData(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }
        public Customer AddCustomer(Customer customer)
        {
            customer.Id = Guid.NewGuid();
            _customerContext.Customers.Add(customer);
            _customerContext.SaveChanges();
            return customer;
        }

        public void DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer EditCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(Guid id)
        {

            var customer = _customerContext.Customers.Find(id);
            return customer;
            // return _customerContext.Customers.SingleOrDefault(x => x.Id == id);
        }

        public List<Customer> GetCustomers()
        {
          
            return _customerContext.Customers.ToList();
        }
    }
}

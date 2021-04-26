using SidmachStore.Models;
using SidmachStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sidmach_Store.Services
{
    public class SqlCustomerData : ICustomer
    {
        private readonly ApplicationDbContext _customerContext;
        public SqlCustomerData(ApplicationDbContext customerContext)
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
            _customerContext.Customers.Remove(customer);
            _customerContext.SaveChanges();
        }

        public Customer EditCustomer(Customer customer)
        {
            var existingCustomer = _customerContext.Customers.Find(customer.Id);
            if(existingCustomer != null)
            {
                _customerContext.Customers.Update(existingCustomer);
                _customerContext.SaveChanges();
            }

            return customer;
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

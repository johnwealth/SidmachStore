using Microsoft.AspNetCore.Mvc;
using SidmachStore.Models;
using SidmachStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SidmachStore.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomer _customer;

        public CustomersController(ICustomer customer)
        {
            _customer = customer;

        }


        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult GetCustomers()
        {
            return Ok(_customer.GetCustomers());
        }


        [HttpGet]
        [Route("api/[controller]/{id}")]

        public IActionResult GetCustomer(Guid id)
        {
            var customer = _customer.GetCustomer(id);

            if(customer != null)
            {
                return Ok(customer);

            }

            return NotFound($"The customer with id : {id} was not found ");
        }


        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult GetCustomers(Customer customer)
        {
            _customer.AddCustomer(customer);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +
                customer.Id, customer);
        }



        [HttpDelete]
        [Route("api/[controller]/{id}")]

        public IActionResult DeleteCustomer(Guid id)
        {
            var customer = _customer.GetCustomer(id);

            if (customer != null)
            {
                _customer.DeleteCustomer(customer);
                return Ok($"The customer with id: { id} was deleted! ");

            }

            return NotFound($"The customer with id : {id} was not found ");
        }


        [HttpPatch]
        [Route("api/[controller]/{id}")]

        public IActionResult EditCustomer(Guid id, Customer customer)
        {
            var existingCustomer = _customer.GetCustomer(id);

            if (existingCustomer != null)
            {
                customer.Id = existingCustomer.Id;
                _customer.EditCustomer(existingCustomer);
                return Ok(customer);

            }

            return NotFound($"The customer with id : {id} was not found ");
        }

    }
}
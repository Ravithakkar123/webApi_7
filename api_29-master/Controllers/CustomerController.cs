using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Interface;
using Webapi.Model;
using Webapi.Repository;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
         private readonly ICustomer _Icustomer;
        public CustomerController(ICustomer customerRepository)
        {

            _Icustomer = customerRepository;
        }
        // GET: api/Customer
        [HttpGet]
        public IActionResult GetCustomer(int pageNumber, int size)
        {
            try
            {
                var customerList = _Icustomer.GetCustomer(pageNumber, size);
                if (customerList == null)
                {
                    return NotFound();
                }                               
                return Ok(customerList);
            }
            catch
            {
                return BadRequest();
            }
        }
      
        // GET: api/Customer/5
        [HttpGet("{id}")]

        public IActionResult GetCustomerById(int id)
        {
          
            try
            {
                var customer = _Icustomer.GetCustomerById(id);

                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, Customer customer)
        {

            try
            {

                if (id != 0)
                {
                    _Icustomer.PutCustomer(id, customer);
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }
        // POST: api/Customer
        [HttpPost]
        public IActionResult PostCustomer([FromBody] Customer customer)
        {
            try
            {
                var cust = _Icustomer.PostCustomer(customer);
                return Ok(cust);

            }
            catch (Exception)
            {
                return NoContent();
            }
        }


        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public  ActionResult<Customer> DeleteCustomer(int id)
        {
            var customer = _Icustomer.DeleteCustomer(id);

            return  customer;
        }
        

    }
}

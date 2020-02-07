using AutoMapper;
using FoodWoodz.DAL.Model;
using FoodWoodz.DAL.Helper;
using FoodWoodz.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using FoodWoodz.DAL.paggingHelper.Interface;

namespace FoodWoodz.DAL.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly RestaurantDataContext _context;
        private readonly IpaggingHelper _paggingHelper;

        public CustomerRepository(RestaurantDataContext context , IpaggingHelper paggingHelper)
        {
               _context = context;
            _paggingHelper = paggingHelper;
        }
       
        public PagedList GetCustomer(int pageNumber, int size)
        {
               
            if (_context != null)
            {
                var pageNum = pageNumber;
                var pageSize = size;
                var customers = from o in _context.Customers
                                select o;
                var customer = _context.Customers.Include(o => o.Addresses).ToList();
                 var list= _paggingHelper.GetCurrentPageRecord(customer, pageNum, pageSize);
                 return list;
            }
            else
            {
                return null;
            }
        }

       
        public  Customer DeleteCustomer(int id)
        {
            var customer = _context.Customers.Where(p => p.CustomerId == id).Include(p => p.Addresses).SingleOrDefault();

            if (customer != null)
            {

                foreach (var child in customer.Addresses.ToList())
                {
                    if (customer.Addresses.Any(c => c.AddressId == child.AddressId))
                        _context.addresses.Remove(child);
                }

                _context.Customers.Remove(customer);
                _context.SaveChangesAsync();
                return customer;
            }
            return customer;
        }



        public  Customer GetCustomerById(int id)
        {
            var customer = _context.Customers.Include(a => a.Addresses).FirstOrDefault(i => i.CustomerId == id);
            return  customer;
        }

        public  Customer PostCustomer(Customer customer)
        {           
             _context.Customers.Add(customer);
             _context.SaveChanges();
            return customer;
        }

        public void PutCustomer(int id, Customer customer)
        {
            var cust = _context.Customers.Where(p => p.CustomerId == customer.CustomerId).Include(p => p.Addresses).SingleOrDefault();

            if (cust != null)
            {
                //update customer
                _context.Entry(cust).CurrentValues.SetValues(customer);
                // Delete address
                foreach (var existingCustomer in cust.Addresses.ToList())
                {
                    if (!customer.Addresses.Any(c => c.AddressId == existingCustomer.AddressId))
                        _context.addresses.Remove(existingCustomer);
                }

                //update and insert address
                foreach (var customerAddress in customer.Addresses)
                {
                    var address_up = cust.Addresses.Where(c => c.AddressId == customerAddress.AddressId).SingleOrDefault();

                    if (address_up != null)
                    {
                        //update address
                        _context.Entry(address_up).CurrentValues.SetValues(customerAddress);
                    }
                    else
                    {
                        //insert address
                        var newitem = new Address
                        {
                            AddressId = customerAddress.AddressId,
                            AddressType = customerAddress.AddressType,
                            Street1 = customerAddress.Street1,
                            Street2 = customerAddress.Street2,
                            City = customerAddress.City,
                            District = customerAddress.District,
                            PinCode = customerAddress.PinCode
                        };
                        cust.Addresses.Add(newitem);
                    }

                }
                    _context.SaveChanges();
            }
        }
    }
}

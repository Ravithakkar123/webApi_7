using FoodWoodz.DAL.Model;
using FoodWoodz.DAL.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodWoodz.DAL.Interface
{
    public interface ICustomer
    {
       
        PagedList GetCustomer(int pageNumber, int size);
        Customer GetCustomerById(int id);
        void PutCustomer(int id, Customer customer);
        Customer PostCustomer(Customer customer);             
        Customer DeleteCustomer(int id);

    }
}

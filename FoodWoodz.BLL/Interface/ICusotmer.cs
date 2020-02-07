using FoodWoodz.BLL.Helper;
using FoodWoodz.BLL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodWoodz.BLL.Interface
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

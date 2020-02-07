using FoodWoodz.DAL.Model;
using FoodWoodz.DAL.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodWoodz.DAL.paggingHelper.Interface
{
    public interface IpaggingHelper
    {
        PagedList GetCurrentPageRecord(IList<Customer> source, int pageNumber, int pageSize);

    }
}

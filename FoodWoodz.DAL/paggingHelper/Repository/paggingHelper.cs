using FoodWoodz.DAL.Helper;
using FoodWoodz.DAL.Model;
using FoodWoodz.DAL.paggingHelper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodWoodz.DAL.paggingHelper.Repository
{
    public class PaggingHelper : IpaggingHelper
    {
        public PagedList GetCurrentPageRecord(IList<Customer> source, int pageNumber, int pageSize)
        {
            var totalCount = source.Count();
            var item = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList(item, totalCount, pageNumber, pageSize);


        }
    }
}

using FoodWoodz.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodWoodz.DAL.Helper
{
    public class PagedList
    {
        public int CurrentPage { get; set; }
        public List<Customer> customers { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious
        {
            get
            {
                return (CurrentPage > 1);
            }
        }
        public bool HasNext
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }
        public PagedList()
        {

        }
        public PagedList(IList<Customer> items, int totalCount, int pageNumber, int pageSize)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(totalCount / (double)(pageSize));
            customers = items.ToList();
        }
     

    }
}

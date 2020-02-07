using FoodWoodz.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodWoodz.BLL.Helper
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
        public PagedList GetCurrentPageRecord(IList<Customer> source, int pageNumber, int pageSize)
        {
            var totalCount = source.Count();
            var item = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList(item, totalCount, pageNumber, pageSize);


        }

    }
}

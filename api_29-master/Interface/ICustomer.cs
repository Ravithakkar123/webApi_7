using Webapi.Model;
using Webapi.Pagging;

namespace Webapi.Interface
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

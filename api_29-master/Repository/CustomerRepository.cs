using AutoMapper;
using Webapi.Pagging;

namespace Webapi.Repository
{
    public class CustomerRepository : Webapi.Interface.ICustomer
    {
        private readonly FoodWoodz.BLL.Interface.ICustomer _Icustomer;
        private readonly IMapper _mapper;
       
        public CustomerRepository(IMapper mapper , FoodWoodz.BLL.Interface.ICustomer customerRepository)
        {
            _mapper = mapper;
             _Icustomer = customerRepository;
        }  
        
        public  PagedList GetCustomer(int pageNumber, int size)
        {
            var customer = _Icustomer.GetCustomer(pageNumber, size);
            var list = _mapper.Map<PagedList> (customer);
            return list;
        }

        public Model.Customer DeleteCustomer(int id)
        {
            var customer = _Icustomer.DeleteCustomer(id);
            Model.Customer c= _mapper.Map<Model.Customer>(customer);
            return c;
        }

        public Model.Customer GetCustomerById(int id)
        {
            var customer = _Icustomer.GetCustomerById(id);
            Model.Customer c = _mapper.Map<Model.Customer>(customer);
            return c;
        }

        public Model.Customer PostCustomer(Model.Customer customer1)
        {
            var c = _mapper.Map<FoodWoodz.BLL.Model.Customer>(customer1);
            var customer = _Icustomer.PostCustomer(c);
            return _mapper.Map<Model.Customer>(customer);
        }

        public void PutCustomer(int id, Model.Customer customer)
        {
          var c= _mapper.Map<FoodWoodz.BLL.Model.Customer>(customer);
                            _Icustomer.PutCustomer(id, c);
        }
    }
}

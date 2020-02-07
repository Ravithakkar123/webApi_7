using AutoMapper;
using FoodWoodz.BLL.Helper;

namespace FoodWoodz.BLL.Repository
{
    public class CustomerRepository : FoodWoodz.BLL.Interface.ICustomer
    {
        private readonly  FoodWoodz.DAL.Interface.ICustomer _Icustomer;
        private readonly IMapper _mapper;

        public CustomerRepository(IMapper mapper, FoodWoodz.DAL.Interface.ICustomer customerRepository)
        {
            _mapper = mapper;
            _Icustomer = customerRepository;
        }
        public PagedList GetCustomer(int pageNumber, int size)
        {
            var customer = _Icustomer.GetCustomer(pageNumber, size);
            PagedList list = _mapper.Map<PagedList>(customer);
            return list;
        }
        public Model.Customer DeleteCustomer(int id)
        {
            var customer = _Icustomer.DeleteCustomer(id);
            Model.Customer c = _mapper.Map<Model.Customer>(customer);
            return c;

        }
        public Model.Customer GetCustomerById(int id)
        {
            var customer = _Icustomer.GetCustomerById(id);
            Model.Customer c = _mapper.Map<FoodWoodz.DAL.Model.Customer, Model.Customer>(customer);
            return c;
        }

        public Model.Customer PostCustomer(Model.Customer customer1)
        {
            var c = _mapper.Map<FoodWoodz.DAL.Model.Customer>(customer1);
            var customer = _Icustomer.PostCustomer(c);
            return _mapper.Map<Model.Customer>(customer);
        }

        public void PutCustomer(int id, Model.Customer customer)
        {
            var c = _mapper.Map<FoodWoodz.DAL.Model.Customer>(customer);
            _Icustomer.PutCustomer(id, c);
        }
    }

}
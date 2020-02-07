using AutoMapper;
using Webapi.Repository;

namespace Webapi.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap< CustomerRepository, FoodWoodz.BLL.Repository.CustomerRepository>().ReverseMap();
            CreateMap<FoodWoodz.BLL.Repository.CustomerRepository,FoodWoodz.DAL.Repository.CustomerRepository>().ReverseMap();
            CreateMap<Pagging.PagedList, FoodWoodz.BLL.Helper.PagedList>().ReverseMap();
            CreateMap<FoodWoodz.BLL.Helper.PagedList, FoodWoodz.DAL.Helper.PagedList>().ReverseMap();
            CreateMap<Model.Customer, FoodWoodz.BLL.Model.Customer>().ReverseMap();
            CreateMap<FoodWoodz.BLL.Model.Customer, FoodWoodz.DAL.Model.Customer>().ReverseMap();
            CreateMap<Model.Address, FoodWoodz.BLL.Model.Address>().ReverseMap();
            CreateMap<FoodWoodz.BLL.Model.Address, FoodWoodz.DAL.Model.Address>().ReverseMap();
        }
    }
}

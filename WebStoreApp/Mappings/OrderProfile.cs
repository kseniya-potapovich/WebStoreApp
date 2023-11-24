using AutoMapper;
using WebStoreApp.Dto;
using WedStoreApp.Entities;

namespace WebStoreApp.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
        }
    }
}

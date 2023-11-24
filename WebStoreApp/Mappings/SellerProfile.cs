using AutoMapper;
using WebStoreApp.Dto;
using WedStoreApp.Entities;

namespace WebStoreApp.Mappings
{
    public class SellerProfile : Profile
    {
        public SellerProfile()
        {
            CreateMap<Seller, SellerDto>().ReverseMap();
            CreateMap<Seller, CreateSellerDto>().ReverseMap();
        }
    }
}

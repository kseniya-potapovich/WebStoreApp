using AutoMapper;
using WebStoreApp.Dto;
using WedStoreApp.Entities;

namespace WebStoreApp.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using WebStoreApp.Dto;
using WedStoreApp.Entities;

namespace WebStoreApp.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
        }
    }
}

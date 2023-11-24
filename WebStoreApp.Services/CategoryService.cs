using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreApp.DataAccess.Repository;
using WebStoreApp.DataAccess.Repository.Concracts;
using WebStoreApp.Dto;
using WebStoreApp.Services.Contract;
using WedStoreApp.Entities;

namespace WebStoreApp.Services
{
    public class CategoryService : ICategoryService
    {
        public readonly ICategoryRepository _categoryRepository;
        public readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(CategoryDto category)
        {
            var categoryToAdd = _mapper.Map<Category>(category);
            return await _categoryRepository.Create(categoryToAdd);
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}

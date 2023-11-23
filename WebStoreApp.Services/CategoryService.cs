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

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task<int> Create(CategoryDto category)
        {
            var categoryToAdd = new Category()
            {
                Name = category.Name,
            };
            return await _categoryRepository.Create(categoryToAdd);
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _categoryRepository.GetById(id);
            var result = new CategoryDto()
            {
                Name=category.Name,
            };
            return result;
        }
    }
}

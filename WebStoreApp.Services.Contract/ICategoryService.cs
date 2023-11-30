using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreApp.Dto;

namespace WebStoreApp.Services.Contract
{
    public interface ICategoryService
    {
        public Task<CategoryDto> GetById(int id);

        public Task<int> Create(CategoryDto category);

        public Task<List<CategoryDto>> GetAll();
    }
}

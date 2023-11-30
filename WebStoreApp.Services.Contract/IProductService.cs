using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreApp.Dto;

namespace WebStoreApp.Services.Contract
{
    public interface IProductService
    {
        public Task<ProductDto> GetById(int id);

        Task<int> Create(ProductDto product);

        Task<List<ProductDto>> GetAll();
    }
}

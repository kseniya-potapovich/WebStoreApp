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
    public class ProductService : IProductService
    {
        public readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Create(ProductDto product)
        {
            var productToAdd = new Product()
            {
                Name = product.Name,
                CategoryId = product.CategoryId,
                SellerId = product.SellerId,
                Discription = product.Discription,
                Price = product.Price,
            };

            return await _productRepository.Create(productToAdd);
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            var result = new ProductDto()
            {
                Name = product.Name,
                CategoryId = product.CategoryId,
                SellerId= product.SellerId,
                Discription = product.Discription,
                Price = product.Price,
            };
            return result;
        }
    }
}

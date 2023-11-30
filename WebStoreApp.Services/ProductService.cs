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
    public class ProductService : IProductService
    {
        public readonly IProductRepository _productRepository;
        public readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(ProductDto product)
        {
            var productToAdd = _mapper.Map<Product>(product);
            return await _productRepository.Create(productToAdd);
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}

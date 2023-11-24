using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreApp.DataAccess.Repository.Concracts;
using WedStoreApp.Entities;

namespace WebStoreApp.DataAccess.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(WebStoreAppDbContext webStoreAppContext) : base(webStoreAppContext)
        {
        }

        public async Task<int> Create(Product product)
        {
            await _webStoreAppContext.Products.AddAsync(product);
            await _webStoreAppContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _webStoreAppContext.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return _webStoreAppContext.Products.SingleOrDefault(p => p.Id == id);
        }
    }
}

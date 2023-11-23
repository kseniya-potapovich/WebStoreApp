using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedStoreApp.Entities;

namespace WebStoreApp.DataAccess.Repository.Concracts
{
    public interface IProductRepository
    {
        Task<Product> GetById(int id);

        Task<List<Product>> GetAll();

        Task<int> Create(Product product);

        Task<int> Delete(int id);
    }
}

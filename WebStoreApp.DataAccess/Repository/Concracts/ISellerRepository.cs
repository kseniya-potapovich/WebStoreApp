using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedStoreApp.Entities;

namespace WebStoreApp.DataAccess.Repository.Concracts
{
    public interface ISellerRepository
    {
        Task<Seller> GetById(int id);

        Task<List<Seller>> GetAll();

        Task<int> Create(Seller seller);

        Task<int> Delete(int id);
    }
}

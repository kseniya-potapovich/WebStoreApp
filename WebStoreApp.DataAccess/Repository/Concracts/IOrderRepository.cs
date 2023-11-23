using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedStoreApp.Entities;

namespace WebStoreApp.DataAccess.Repository.Concracts
{
    public interface IOrderRepository
    {
        Task<Order> GetById(int id);

        Task<List<Order>> GetAll();

        Task<int> Create(Order order);

        Task<int> Delete(int id);
    }
}

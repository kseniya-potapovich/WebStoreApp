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
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(WebStoreAppDbContext webStoreAppContext) : base(webStoreAppContext)
        {
        }

        public async Task<int> Create(Order order)
        {
            await _webStoreAppContext.Orders.AddAsync(order);
            await _webStoreAppContext.SaveChangesAsync();
            return order.Id;
        }

        public async Task<int> Delete(int id)
        {
            var order = await _webStoreAppContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
            _webStoreAppContext.Remove(order);
            await _webStoreAppContext.SaveChangesAsync();
            return order.Id;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _webStoreAppContext.Orders.ToListAsync();
        }

        public Task<Order> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStoreApp.DataAccess;
using WedStoreApp.Entities;

namespace WebStoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController: ControllerBase
    {
        public readonly WebStoreAppDbContext _webStoreAppContext;

        public OrderController(WebStoreAppDbContext webStoreAppContext)
        {
            _webStoreAppContext = webStoreAppContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            return await _webStoreAppContext.Orders.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] Order order)
        {
            await _webStoreAppContext.Orders.AddAsync(order);
            await _webStoreAppContext.SaveChangesAsync();
            return order.Id;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete([FromBody] int orderId)
        {
            var order = await _webStoreAppContext.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
            _webStoreAppContext.Remove(order);
            await _webStoreAppContext.SaveChangesAsync();
            return order.Id;
        }
    }
}

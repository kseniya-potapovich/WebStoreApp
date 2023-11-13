using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStoreApp.DataAccess;
using WedStoreApp.Entities;

namespace WebStoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellerController: ControllerBase
    {
        public readonly WebStoreAppDbContext _webStoreAppContext;

        public SellerController(WebStoreAppDbContext webStoreAppContext)
        {
            _webStoreAppContext = webStoreAppContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seller>>> GetAll() 
        {
            return await _webStoreAppContext.Sellers.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] Seller seller)
        {
            await _webStoreAppContext.Sellers.AddAsync(seller);
            await _webStoreAppContext.SaveChangesAsync();
            return seller.Id;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete([FromBody] int sellerId)
        {
            var seller = await _webStoreAppContext.Sellers.FirstOrDefaultAsync(x => x.Id == sellerId);
            _webStoreAppContext.Remove(seller);
            await _webStoreAppContext.SaveChangesAsync();
            return seller.Id;
        }
    }
}

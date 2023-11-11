using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStoreApp.DataAccess;
using WedStoreApp.Entities;

namespace WebStoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public readonly WebStoreAppDbContext _webStoreAppContext;

        public ProductController(WebStoreAppDbContext webStoreAppContext, WebStoreAppDbContext id)
        {
            _webStoreAppContext = webStoreAppContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            return await _webStoreAppContext.Products.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] Product product)
        {
            await _webStoreAppContext.Products.AddAsync(product);
            await _webStoreAppContext.SaveChangesAsync();
            return product.Id;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete([FromBody] int productId)
        {
            var product = await _webStoreAppContext.Products.FirstOrDefaultAsync(x => x.Id == productId);
            _webStoreAppContext.Remove(product);
            await _webStoreAppContext.SaveChangesAsync();
            return product.Id;
        }

    }
}
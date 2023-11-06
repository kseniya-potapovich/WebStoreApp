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

        public ProductController(WebStoreAppDbContext webStoreAppContext)
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
    }
}
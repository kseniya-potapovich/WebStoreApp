using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStoreApp.DataAccess;
using WedStoreApp.Entities;

namespace WebStoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController: ControllerBase
    {
        public readonly WebStoreAppDbContext _webStoreAppContext;

        public CategoryController(WebStoreAppDbContext webStoreAppContext)
        {
            _webStoreAppContext = webStoreAppContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            return await _webStoreAppContext.Categories.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] Category category)
        {
            await _webStoreAppContext.Categories.AddAsync(category);
            await _webStoreAppContext.SaveChangesAsync();
            return category.Id;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete([FromBody] int categoryId)
        {
            var category = await _webStoreAppContext.Orders.FirstOrDefaultAsync(x => x.Id == categoryId);
            _webStoreAppContext.Remove(category);
            await _webStoreAppContext.SaveChangesAsync();
            return category.Id;
        }
    }
}

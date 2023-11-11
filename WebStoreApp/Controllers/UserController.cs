using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStoreApp.DataAccess;
using WedStoreApp.Entities;

namespace WebStoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        public readonly WebStoreAppDbContext _webStoreAppContext;

        public UserController(WebStoreAppDbContext webStoreAppContext)
        {
            _webStoreAppContext = webStoreAppContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await _webStoreAppContext.Users.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] User user)
        {
            await _webStoreAppContext.Users.AddAsync(user);
            await _webStoreAppContext.SaveChangesAsync();
            return user.Id;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete([FromBody] int userId)
        {
            var user = await _webStoreAppContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            _webStoreAppContext.Remove(user);
            await _webStoreAppContext.SaveChangesAsync();
            return user.Id;
        }

    }
}

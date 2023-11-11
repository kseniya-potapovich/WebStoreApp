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

       
    }
}

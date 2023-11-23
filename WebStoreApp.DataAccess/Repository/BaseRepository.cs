using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreApp.DataAccess.Repository
{
    public class BaseRepository
    {
        public readonly WebStoreAppDbContext _webStoreAppContext;

        public BaseRepository(WebStoreAppDbContext webStoreAppContext)
        {
            _webStoreAppContext = webStoreAppContext;
        }
    }
}

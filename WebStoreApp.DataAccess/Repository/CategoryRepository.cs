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
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(WebStoreAppDbContext webStoreAppContext) : base(webStoreAppContext)
        {
        }

        public async Task<int> Create(Category category)
        {
            await _webStoreAppContext.Categories.AddAsync(category);
            await _webStoreAppContext.SaveChangesAsync();
            return category.Id;
        }

        public async Task<int> Delete(int id)
        {
            var category = await _webStoreAppContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            _webStoreAppContext.Remove(category);
            await _webStoreAppContext.SaveChangesAsync();
            return category.Id;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _webStoreAppContext.Categories.ToListAsync();
        }

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedStoreApp.Entities;

namespace WebStoreApp.DataAccess.Repository.Concracts
{
    public interface ICategoryRepository
    {
        Task<Category> GetById(int id);

        Task<List<Category>> GetAll();

        Task<int> Create(Category category);

        Task<int> Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedStoreApp.Entities;

namespace WebStoreApp.DataAccess.Repository.Concracts
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);

        Task<List<User>> GetAll();

        Task<int> Create(User user);

    }
}

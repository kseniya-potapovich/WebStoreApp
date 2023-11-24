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
    public class UserRepository :BaseRepository, IUserRepository
    {
        public UserRepository(WebStoreAppDbContext webStoreAppContext) : base(webStoreAppContext)
        {
        }

        public async Task<List<User>> GetAll()
        {
            return await _webStoreAppContext.Users.ToListAsync();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(User user)
        {
            await _webStoreAppContext.Users.AddAsync(user);
            await _webStoreAppContext.SaveChangesAsync();
            return user.Id;
        }
    }
}

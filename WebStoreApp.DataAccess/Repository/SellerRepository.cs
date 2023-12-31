﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreApp.DataAccess.Repository.Concracts;
using WedStoreApp.Entities;

namespace WebStoreApp.DataAccess.Repository
{
    public class SellerRepository : BaseRepository, ISellerRepository
    {
        public SellerRepository(WebStoreAppDbContext webStoreAppContext) : base(webStoreAppContext)
        {
        }

        public async Task<int> Create(Seller seller)
        {
            await _webStoreAppContext.Sellers.AddAsync(seller);
            await _webStoreAppContext.SaveChangesAsync();
            return seller.Id;
        }

        public async Task<List<Seller>> GetAll()
        {
            return await _webStoreAppContext.Sellers.ToListAsync();
        }

        public async Task<Seller> GetById(int id)
        {
            return _webStoreAppContext.Sellers.FirstOrDefault(s => s.Id == id);
        }
    }
}

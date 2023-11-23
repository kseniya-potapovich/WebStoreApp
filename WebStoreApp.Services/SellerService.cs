using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreApp.DataAccess.Repository;
using WebStoreApp.DataAccess.Repository.Concracts;
using WebStoreApp.Dto;
using WebStoreApp.Services.Contract;
using WedStoreApp.Entities;

namespace WebStoreApp.Services
{
    public class SellerService : ISellerService
    {
        public readonly ISellerRepository _sellerRepository;

        public SellerService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<int> Create(SellerDto seller)
        {
            var sellerToAdd = new Seller()
            {
                NameCompany = seller.NameCompany,
                Reviews = seller.Reviews
            };

            return await _sellerRepository.Create(sellerToAdd);
        }

        public async Task<SellerDto> GetById(int id)
        {
            var seller = await _sellerRepository.GetById(id);
            var result = new SellerDto()
            {
                NameCompany = seller.NameCompany,
                Reviews = seller.Reviews
            };
            return result;
        }
    }
}

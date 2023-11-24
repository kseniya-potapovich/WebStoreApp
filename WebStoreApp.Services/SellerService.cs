using AutoMapper;
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
    public class SellerService: ISellerService
    {
        public readonly ISellerRepository _sellerRepository;
        public readonly IMapper _mapper;

        public SellerService(ISellerRepository sellerRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(SellerDto seller)
        {
            var sellerToAdd = _mapper.Map<Seller>(seller);
            return await _sellerRepository.Create(sellerToAdd);
        }

        public async Task<SellerDto> GetById(int id)
        {
            var seller = await _sellerRepository.GetById(id);
            return _mapper.Map<SellerDto>(seller);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreApp.Dto;

namespace WebStoreApp.Services.Contract
{
    public interface ISellerService
    {
        public Task<SellerDto> GetById(int id);

        Task<int> Create(SellerDto seller);
    }
}

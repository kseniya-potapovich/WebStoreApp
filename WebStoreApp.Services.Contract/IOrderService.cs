using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreApp.Dto;

namespace WebStoreApp.Services.Contract
{
    public interface IOrderService
    {
        Task<OrderDto> GetById(int id);

        Task<int> Create(OrderDto order);

        Task<List<OrderDto>> GetAll();
    }
}

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
    public class OrderService : IOrderService
    {
        public readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public async Task<int> Create(OrderDto order)
        {
            var orderToAdd = new Order()
            {
                ProductId = order.ProductId,
                UserId = order.UserId,
            };
            return await _orderRepository.Create(orderToAdd);
        }

        public async Task<OrderDto> GetById(int id)
        {
            var order = await _orderRepository.GetById(id);
            var result = new OrderDto()
            {
                ProductId = order.ProductId,
                UserId = order.UserId,
            };
            return result;
        }
    }
}

using AutoMapper;
using Moq;
using WebStoreApp.DataAccess.Repository.Concracts;
using WebStoreApp.Dto;
using WebStoreApp.Mappings;
using WebStoreApp.Services.Contract;
using WebStoreApp.Services;
using WedStoreApp.Entities;

namespace WebStoreApp.UnitTests.Services
{
    public class OrderServiceTest
    {
        [Fact]
        public async void Create_ValidOrder_Ok()
        {
            var orderId = 1;
            var orderToAdd = new OrderDto()
            {
                ProductId = 123,
                UserId = 123,
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(x => x.GetById(orderToAdd.Id)).Returns(Task.FromResult((Order)null));
            orderRepositoryMock.Setup(x => x.Create(It.IsAny<Order>())).ReturnsAsync(orderId);

            var orderService = GetOrderService(orderRepositoryMock.Object);

            //act
            var result = await orderService.Create(orderToAdd);

            //assert
            Assert.Equal(orderId, result);

            orderRepositoryMock.Verify(x => x.Create(It.IsAny<Order>()));
        }

        [Fact]
        public async void Create_OrderExist_ThrowExeption()
        {
            //arrange
            var orderToAdd = new OrderDto()
            {
                ProductId = 123,
                UserId = 123,
            };
            var existedOrder = new Order()
            {
                ProductId = 123,
                UserId = 123,
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();

            orderRepositoryMock.Setup(x => x.GetById(orderToAdd.Id)).ReturnsAsync(existedOrder);

            var orderService = GetOrderService(orderRepositoryMock.Object);

            //act
            //assert
            await Assert.ThrowsAsync<Exception>(() => orderService.Create(orderToAdd));
        }

        private IOrderService GetOrderService(IOrderRepository orderRepository)
        {
            var assemblies = new[]
            {
                typeof(OrderProfile).Assembly,
            };
            var mapConfig = new MapperConfiguration(config => config.AddMaps(assemblies));
            var mapper = mapConfig.CreateMapper();
            return new OrderService(orderRepository, mapper);
        }
    }
}

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
    public class ProductServiceTest
    {
        [Fact]
        public async void Create_ValidProduct_Ok()
        {
            var productId = 1;
            var productToAdd = new ProductDto()
            {
                Name = "test name",
                Discription = "test description",
                Price = 1234,

            };

            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(x => x.GetById(productToAdd.Id)).Returns(Task.FromResult((Product)null));
            productRepositoryMock.Setup(x => x.Create(It.IsAny<Product>())).ReturnsAsync(productId);

            var sellerService = GetProductService(productRepositoryMock.Object);

            //act
            var result = await sellerService.Create(productToAdd);

            //assert
            Assert.Equal(productId, result);

            productRepositoryMock.Verify(x => x.Create(It.IsAny<Product>()));
        }

        [Fact]
        public async void Create_ProductExist_ThrowExeption()
        {
            //arrange
            var productToAdd = new ProductDto()
            {
                Name = "test name",
                Discription = "test description",
                Price = 1234,
            };
            var existedProduct = new Product()
            {
                Name = "test name",
                Discription = "test description",
                Price = 1234,
            };

            var productRepositoryMock = new Mock<IProductRepository>();

            productRepositoryMock.Setup(x => x.GetById(productToAdd.Id)).ReturnsAsync(existedProduct);

            var sellerService = GetProductService(productRepositoryMock.Object);

            //act
            //assert
            await Assert.ThrowsAsync<Exception>(() => sellerService.Create(productToAdd));
        }

        private IProductService GetProductService(IProductRepository productRepository)
        {
            var assemblies = new[]
            {
                typeof(ProductProfile).Assembly,
            };
            var mapConfig = new MapperConfiguration(config => config.AddMaps(assemblies));
            var mapper = mapConfig.CreateMapper();
            return new ProductService(productRepository, mapper);
        }
    }
}

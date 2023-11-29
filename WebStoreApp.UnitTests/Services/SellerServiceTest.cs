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
    public class SellerServiceTest
    {
        [Fact]
        public async void Create_ValidSeller_Ok()
        {
            //arrange
            var sellerId = 1;
            var sellerToAdd = new SellerDto()
            {
                NameCompany = "Name Company",
                Reviews = "rewiews",
            };

            var sellerRepositoryMock = new Mock<ISellerRepository>();
            sellerRepositoryMock.Setup(x => x.GetById(sellerToAdd.Id)).Returns(Task.FromResult((Seller)null));
            sellerRepositoryMock.Setup(x => x.Create(It.IsAny<Seller>())).ReturnsAsync(sellerId);

            var sellerService = GetSellerService(sellerRepositoryMock.Object);

            //act
            var result = await sellerService.Create(sellerToAdd);

            //assert
            Assert.Equal(sellerId, result);

            sellerRepositoryMock.Verify(x => x.Create(It.IsAny<Seller>()));
        }


        [Fact]
        public async void Create_SellerExist_ThrowExeption()
        {
            //arrange
            var sellerToAdd = new SellerDto()
            {
                NameCompany = "Name Company",
                Reviews = "rewiews",
            };
            var existedSeller = new Seller()
            {
                NameCompany = "Name Company",
                Reviews = "rewiews",
            };

            var sellerRepositoryMock = new Mock<ISellerRepository>();

            sellerRepositoryMock.Setup(x => x.GetById(sellerToAdd.Id)).ReturnsAsync(existedSeller);

            var sellerService = GetSellerService(sellerRepositoryMock.Object);

            //act
            //assert
            await Assert.ThrowsAsync<Exception>(() => sellerService.Create(sellerToAdd));
        }

        private ISellerService GetSellerService(ISellerRepository sellerRepository)
        {
            var assemblies = new[]
            {
                typeof(SellerProfile).Assembly,
            };
            var mapConfig = new MapperConfiguration(config => config.AddMaps(assemblies));
            var mapper = mapConfig.CreateMapper();
            return new SellerService(sellerRepository, mapper);
        }
    }
}

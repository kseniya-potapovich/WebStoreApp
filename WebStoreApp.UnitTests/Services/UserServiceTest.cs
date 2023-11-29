using AutoMapper;
using WebStoreApp.DataAccess.Repository.Concracts;
using WebStoreApp.Dto;
using WebStoreApp.Mappings;
using WebStoreApp.Services.Contract;
using WebStoreApp.Services;
using Moq;
using WedStoreApp.Entities;

namespace WebStoreApp.UnitTests.Services
{
    public class UserServiceTest
    {
        [Fact]
        public async void Create_ValidUser_Ok()
        {
            //arrange
            var userId = 1;
            var userToAdd = new UserDto()
            {
                FirstName = "Ivanov",
                LastName = "Ivan",
                Email = "Test",
            };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x =>x.GetById(userToAdd.Id)).Returns(Task.FromResult((User)null));
            userRepositoryMock.Setup(x =>x.Create(It.IsAny<User>())).ReturnsAsync(userId);

            var userService = GetUserService(userRepositoryMock.Object);

            //act
            var result = await userService.Create(userToAdd);

            //assert
            Assert.Equal(userId, result);

            userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()));
        }


        [Fact]
        public async void Create_ValidUser_ThrowExeption()
        {
            //arrange
            var userToAdd = new UserDto()
            {
                FirstName = "Ivanov",
                LastName = "Ivan",
                Email = "Test",
            };
            var userExit = new User()
            {
                FirstName = "Ivanov",
                LastName = "Ivan",
                Email = "Test",
            };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetById(userToAdd.Id)).ReturnsAsync(userExit);

            var userService = GetUserService(userRepositoryMock.Object);

            //act
            //assert
            await Assert.ThrowsAsync<ArgumentException>(() => userService.Create(userToAdd));
        }

        private IUserService GetUserService(IUserRepository userRepository)
        {
            var assemblies = new[]
            {
                typeof(UserProfile).Assembly,
            };
            var mapConfig = new MapperConfiguration(config => config.AddMaps(assemblies));
            var mapper = mapConfig.CreateMapper();
            return new UserService(userRepository, mapper);
        }
    }
}
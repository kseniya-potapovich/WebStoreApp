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
    public class CategoryServiceTest
    {
        [Fact]
        public async void Create_ValidCategory_Ok()
        {
            var categoryId = 1;
            var categoryToAdd = new CategoryDto()
            {
                Name = "test name"
            };

            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            categoryRepositoryMock.Setup(x => x.GetById(categoryToAdd.Id)).Returns(Task.FromResult((Category)null));
            categoryRepositoryMock.Setup(x => x.Create(It.IsAny<Category>())).ReturnsAsync(categoryId);

            var categoryService = GetCategoryService(categoryRepositoryMock.Object);

            //act
            var result = await categoryService.Create(categoryToAdd);

            //assert
            Assert.Equal(categoryId, result);

            categoryRepositoryMock.Verify(x => x.Create(It.IsAny<Category>()));
        }

        [Fact]
        public async void Create_CategoryExist_ThrowExeption()
        {
            //arrange
            var categoryToAdd = new CategoryDto()
            {
                Name = "test name"
            };
            var existedCategory = new Category()
            {
                Name = "test name"
            };

            var categoryRepositoryMock = new Mock<ICategoryRepository>();

            categoryRepositoryMock.Setup(x => x.GetById(categoryToAdd.Id)).ReturnsAsync(existedCategory);

            var categoryService = GetCategoryService(categoryRepositoryMock.Object);

            //act
            //assert
            await Assert.ThrowsAsync<Exception>(() => categoryService.Create(categoryToAdd));
        }

        private ICategoryService GetCategoryService(ICategoryRepository categoryRepository)
        {
            var assemblies = new[]
            {
                typeof(CategoryProfile).Assembly,
            };
            var mapConfig = new MapperConfiguration(config => config.AddMaps(assemblies));
            var mapper = mapConfig.CreateMapper();
            return new CategoryService(categoryRepository, mapper);
        }
    }
}

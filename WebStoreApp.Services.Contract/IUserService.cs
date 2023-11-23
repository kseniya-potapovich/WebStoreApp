using WebStoreApp.Dto;

namespace WebStoreApp.Services.Contract
{
    public interface IUserService
    {
        public Task<UserDto> GetById(int id);

        Task<int> Create(UserDto user);
    }
}
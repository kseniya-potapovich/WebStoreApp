using WebStoreApp.Dto;

namespace WebStoreApp.Services.Contract
{
    public interface IUserService
    {
        public Task<UserDto> GetById(int id);

        Task<int> Create(UserDto user);

        Task<List<UserDto>> GetAll();

        //Task<int> Update(UserDto user);
    }
}
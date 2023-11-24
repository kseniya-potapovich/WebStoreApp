using AutoMapper;
using WebStoreApp.DataAccess.Repository.Concracts;
using WebStoreApp.Dto;
using WebStoreApp.Services.Contract;
using WedStoreApp.Entities;

namespace WebStoreApp.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _userMapper;

        public UserService(IUserRepository userRepository, IMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        public async Task<int> Create(UserDto user)
        {
            var userToAdd = _userMapper.Map<User>(user);
            return await _userRepository.Create(userToAdd);
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            return _userMapper.Map<UserDto>(user);
        }
    }
}
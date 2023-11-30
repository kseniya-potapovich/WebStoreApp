using System.Net.Http.Json;
using WebStoreApp.Dto;
using WebStoreApp.Services.Contract;

namespace WebStoreApp.Web.Requests
{
    public class ApiUserService : IUserService
    {
        protected readonly HttpClient _httpClient;

        public ApiUserService(HttpClient httpClient) {  _httpClient = httpClient; }

        public Task<int> Create(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDto>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<List<UserDto>>($"User");
            return response ?? throw new HttpRequestException("Coudn't get User");
        }

       // public Task<int> Update(UserDto user) {  throw new NotImplementedException(); }
    }
}

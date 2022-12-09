using System.Net;
using TestKonexa.API.Model;

namespace TestKonexa.API.Service
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsers();
    }

    public class UsersService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<User>> GetAllUsers()
        {
            var url = "https://jsonplaceholder.typicode.com/users";
            var usersResponse = await _httpClient.GetAsync(url);
            if(usersResponse.StatusCode == HttpStatusCode.NotFound) return new List<User>();
            var responseContent = usersResponse.Content;
            var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();
            return allUsers.ToList();
        }
    }
}

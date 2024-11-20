using System.Text.Json;
using ApiContracts;
using User = GithubTest.User;

namespace Client.Services;

public class HttpUserService : IUserService
{
    private readonly HttpClient _httpClient;
    
    public HttpUserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public Task<UserCreateDTO> AddUserAsync(UserCreateDTO request)
    {
        var httpResponse = _httpClient.PostAsJsonAsync("/api/users", request);
        var content = httpResponse.Result.Content.ReadAsStringAsync();
        var user = JsonSerializer.Deserialize<UserCreateDTO>(content.Result);
        return Task.FromResult(user);
    }

    public Task<User> GetUserAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>?> GetUsersAsync()
    {
        try
        {
            // Make the GET request and wait asynchronously for the response
            var httpResponse = await _httpClient.GetAsync("/api/users");

            // Ensure the request was successful
            httpResponse.EnsureSuccessStatusCode();

            // Read and deserialize the content
            var content = await httpResponse.Content.ReadAsStringAsync();

            // Optionally, log the content for debugging
            Console.WriteLine($"Response Content: {content}");

            var users = JsonSerializer.Deserialize<List<User>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Handle case differences in JSON keys
            });

            return users;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Request error: {ex.Message}");
            return null;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Serialization error: {ex.Message}");
            return null;
        }
    }


    public Task<UserReadDTO> UpdateUserAsync(int id, UserUpdateDTO request)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(int id)
    {
        throw new NotImplementedException();
    }
}
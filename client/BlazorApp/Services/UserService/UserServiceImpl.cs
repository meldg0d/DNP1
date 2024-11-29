using System.Text.Json;
using ApiContracts.DTOs.UserDTOs;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BlazorApp.Services.UserService;

public class UserServiceImpl(HttpClient client) : IUserService
{
    
    
    public async Task<UserResponse> AddAsync(UserRequest user)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/users", user);
        
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<UserResponse>();
    }

    public Task UpdateAsync(UserRequest user)
    {
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        return Task.CompletedTask;
    }

    public Task<UserResponse> GetSingleAsync(int id)
    {
        return null;
    }

    public IQueryable<UserResponse> GetManyAsync()
    {
        return Enumerable.Empty<UserResponse>().AsQueryable();
    }
}
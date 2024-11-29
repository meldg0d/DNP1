using ApiContracts.DTOs.UserDTOs;

namespace BlazorApp.Services.UserService;

public interface IUserService
{
    Task<UserResponse> AddAsync(UserRequest user);
    Task UpdateAsync(UserRequest user);
    Task DeleteAsync(int id);
    Task<UserResponse> GetSingleAsync(int id);
    IQueryable<UserResponse> GetManyAsync();
}
using ApiContracts.DTOs.UserDTOs;
using Entities;

namespace RepositoryContracts;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
    Task<User> GetSingleAsync(int id);
    IQueryable<User> GetManyAsync();
    Task<UserResponse> AuthLoginASync(User user);
}
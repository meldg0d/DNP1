using ApiContracts;
using User = GithubTest.User;

namespace Client.Services;

public interface IUserService
{
    public Task<UserCreateDTO> AddUserAsync(UserCreateDTO request);
    public Task<User> GetUserAsync(int id);
    public Task<List<User>> GetUsersAsync();
    public Task<UserReadDTO> UpdateUserAsync(int id, UserUpdateDTO request);
    public Task DeleteUserAsync(int id);
}
namespace GithubTest;

public interface IUserRepository
{
    Task<User> GetUserAsync(int id);
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(User user);
    Task<List<User>> GetAllUsersAsync();
    
}
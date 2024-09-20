namespace GithubTest;

public interface IUserRepository
{
    Task<User> GetUserAsync(int id);
    Task AddUserAsync(User user);
    
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(User user);
    Task DeleteUserAsync(string username);
    
    Task DeleteAllUsersAsync();
    
    Task<User> GetUserAsync(string username);

    Task<List<User>> GetAllUsersAsync();
    
    Task SeedUsersAsync(int count);
    
}
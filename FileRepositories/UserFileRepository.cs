using GithubTest;

namespace FileRepositories;

public class UserFileRepository : IUserRepository
{
    public Task<User> GetUserAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task SeedUsersAsync(int count)
    {
        throw new NotImplementedException();
    }
}
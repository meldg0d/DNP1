using GithubTest;

namespace InMemoryRepositories;

public class UserInMemoryRepository : IUserRepository
{
    private readonly List<User> _users = new();
    
    public Task<User> GetUserAsync(int id)
    {
        // Find the user by email using SingleOrDefault, which returns null if no match is found
        User? userToGet = _users.SingleOrDefault(p => p.Id == id);
        if (userToGet is null)
        {
            throw new InvalidOperationException("User not found");   
        }
        
        return Task.FromResult(userToGet);
    }

    public Task<List<User>> GetAllUsersAsync()
    {
        return Task.Run(() => _users.ToList());
    }

    public Task AddUserAsync(User user)
    {
        user.Id = _users.Any() ? _users.Max(p => p.Id) + 1 : 1;
        _users.Add(user);
        return Task.FromResult(user);
    }

    public Task UpdateUserAsync(User user)
    {
        User? userToUpdate = _users.SingleOrDefault(p => p.Id == user.Id);
        if (userToUpdate is null)
        {
            throw new InvalidOperationException("User not found");
        }
        
        _users.Remove(userToUpdate);
        _users.Add(user);
        return Task.FromResult(user);
    }

    public Task DeleteUserAsync(User user)
    {
        User? userToDelete = _users.SingleOrDefault(p => p.Id == user.Id);
        if (userToDelete is null)
        {
            throw new InvalidOperationException("User not found");
        }
        
        _users.Remove(userToDelete);
        _users.Add(userToDelete);
        return Task.FromResult(user);
    }


}
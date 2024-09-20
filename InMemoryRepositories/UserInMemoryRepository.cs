using GithubTest;

namespace InMemoryRepositories;

public class UserInMemoryRepository : IUserRepository
{
    private readonly List<User> _users = new();
    
    
    /// <summary>
    /// This is just for random generation while testing
    /// </summary>
    public async Task SeedUsersAsync(int numberOfUsers)
    {
        Random random = new Random();

        for (int i = 0; i < numberOfUsers; i++)
        {
            // Generate random username and password
            string username = $"User_{GenerateRandomString(2, random)}";
            string password = GenerateRandomString(8, random);
                
            // Add the user to the repository
            User user = new User(username, password);
            await AddUserAsync(user);
        }
    }

    // Utility method to generate random strings
    private static string GenerateRandomString(int length, Random random)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    
    /// <summary>
    /// Code begins here
    /// </summary>
    
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
    

    public Task<User> GetUserAsync(string username)
    {
        User? userToGet = _users.SingleOrDefault(u => u.Username == username);
    
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
        return Task.FromResult(user);
    }

    public Task DeleteUserAsync(string usernameToDelete)
    {
        List<User> usersToDelete = _users.Where(p => p.Username == usernameToDelete).ToList();
        if (usersToDelete.Count == 0)
        {
            throw new InvalidOperationException("User not found");
        }
        
        _users.Remove(usersToDelete.First());
        return Task.FromResult(usersToDelete);
    }

    public Task DeleteAllUsersAsync()
    {
        _users.Clear();
        return Task.FromResult(0);
    }


}
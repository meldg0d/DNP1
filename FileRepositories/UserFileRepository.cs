using System.Text.Json;
using GithubTest;

namespace FileRepositories;

public class UserFileRepository : IUserRepository
{
    private readonly string _filePath = "comments.json";

    public UserFileRepository()
    {
        if (!File.Exists(_filePath))
        {
            Console.WriteLine("Creating file");
            File.WriteAllText(_filePath, "[]");
        }
    }

    public async Task<User> GetUserAsync(int id)
    {
        var json = await File.ReadAllTextAsync(_filePath);
        var users = JsonSerializer.Deserialize<List<User>>(json);
        return users?.FirstOrDefault(u => u.Id == id);
    }

    public async Task AddUserAsync(User user)
    {
        var json = await File.ReadAllTextAsync(_filePath);
        var users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        user.Id = GetNextId(users);
        users.Add(user);
        json = JsonSerializer.Serialize(users);
        await File.WriteAllTextAsync(_filePath, json);
    }

    private int GetNextId(List<User> users)
    {
        return users.Any() ? users.Max(u => u.Id) + 1 : 1;
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

    public async Task DeleteAllUsersAsync()
    {
        var lines = await File.ReadAllLinesAsync(_filePath);
        var nonUserLines = lines.Where(line => line.TrimStart().StartsWith("//")).ToList();
        var json = JsonSerializer.Serialize(new List<User>());
        nonUserLines.Add(json);
        await File.WriteAllLinesAsync(_filePath, nonUserLines);
    }

    public Task<User> GetUserAsync(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        var users = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<List<User>>(users) ?? new List<User>();
    }

    public Task SeedUsersAsync(int count)
    {
        throw new NotImplementedException();
    }
}
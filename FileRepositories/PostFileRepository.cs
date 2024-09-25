using GithubTest;

namespace FileRepositories;

public class PostFileRepository : IPostRepository
{
    private readonly string _filePath = "comments.json";

    public PostFileRepository()
    {
        if (!File.Exists(_filePath))
        {
            Console.WriteLine("Creating file");
            File.WriteAllText(_filePath, "[]");
        }
    }

    public Task<Post> AddAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Post> GetSingleAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Post> GetAll()
    {
        throw new NotImplementedException();
    }
}
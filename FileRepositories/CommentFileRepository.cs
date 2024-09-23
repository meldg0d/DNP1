using System.Text.Json;
using GithubTest;

namespace FileRepositories;

public class CommentFileRepository : ICommentRepository
{
    
    private readonly string filePath = "comments.json";

    public CommentFileRepository()
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "[]");
        }
    }
    
    public IQueryable<Comment> GetManyAsync()
    {
        var commentsAsJson = File.ReadAllTextAsync(filePath).Result;
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson);
        return comments.AsQueryable();
    }
    

    Task<List<Comment>> ICommentRepository.GetAllCommentsAsync()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Comment> GetCommentsQuery()
    {
        throw new NotImplementedException();
    }

    public Task<Comment> GetCommentByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Comment> CreateCommentAsync(Comment comment)
    {
        var commentsAsJson = await File.ReadAllTextAsync(filePath);
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson);
        int maxId = comments.Count > 0 ? comments.Max(c => c.Id) : 1;
        comment.Id = maxId + 1;
        comments.Add(comment);
        commentsAsJson = JsonSerializer.Serialize(comments);
        await File.WriteAllTextAsync(filePath, commentsAsJson);
        return comment;
    }

    public Task<Comment> UpdateCommentAsync(Comment comment)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCommentAsync(Comment comment)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCommentByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Comment>> GetCommentsByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }
}
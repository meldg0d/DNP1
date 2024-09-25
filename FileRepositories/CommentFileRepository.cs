using System.Text.Json;
using GithubTest;

namespace FileRepositories;

public class CommentFileRepository : ICommentRepository
{
    
    private readonly string _filePath = "comments.json";

    public CommentFileRepository()
    {
        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
        }
    }
    
    public IQueryable<Comment> GetManyAsync()
    {
        var commentsAsJson = File.ReadAllTextAsync(_filePath).Result;
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson) ?? new List<Comment>();
        return comments.AsQueryable();
    }
    

    Task<List<Comment>> ICommentRepository.GetAllCommentsAsync()
    {
        return Task.FromResult(GetManyAsync().ToList());
    }

    public IQueryable<Comment> GetCommentsQuery()
    {
        throw new NotImplementedException();
    }

    public async Task<Comment> GetCommentByIdAsync(int id)
    {
        var comment = await File.ReadAllTextAsync(_filePath);
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(comment) ?? new List<Comment>();
        Comment? commentToReturn = comments.FirstOrDefault(c => c.Id == id) ?? throw new InvalidOperationException("No comment found"); ;
        return commentToReturn;
    }

    public async Task<Comment> CreateCommentAsync(Comment comment)
    {
        var commentsAsJson = await File.ReadAllTextAsync(_filePath);
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson) ?? new List<Comment>();
        int maxId = comments.Count > 0 ? comments.Max(c => c.Id) : 0;
        comment.Id = maxId + 1;
        comments.Add(comment);
        commentsAsJson = JsonSerializer.Serialize(comments);
        await File.WriteAllTextAsync(_filePath, commentsAsJson);
        return comment;
    }

    public async Task<Comment> UpdateCommentAsync(Comment comment)
    {
        var commentAsJson = await File.ReadAllTextAsync(_filePath);
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(commentAsJson) ?? new List<Comment>();
        Comment? existingComment = comments.FirstOrDefault(c => c.Id == comment.Id) ?? throw new InvalidOperationException("No comment found");
        comments.Remove(existingComment);
        comments.Add(comment);
        commentAsJson = JsonSerializer.Serialize(comments);
        await File.WriteAllTextAsync(_filePath, commentAsJson);
        return comment;
    }

    public async Task DeleteCommentAsync(Comment comment)
    {
        
        var commentsAsJson = await File.ReadAllTextAsync(_filePath);
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson) ?? new List<Comment>();
        Comment? existingComment = comments.FirstOrDefault(c => c.Id == comment.Id) ?? throw new InvalidOperationException("No comment found");
        comments.Remove(existingComment);
        commentsAsJson = JsonSerializer.Serialize(comments);
        await File.WriteAllTextAsync(_filePath, commentsAsJson);
    }

    public async Task DeleteCommentByIdAsync(int id)
    {
        var commentsAsJson = await File.ReadAllTextAsync(_filePath);
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson) ?? new List<Comment>();
        Comment? existingComment = comments.FirstOrDefault(c => c.Id == id) ?? throw new InvalidOperationException("No comment found");
        comments.Remove(existingComment);
        commentsAsJson = JsonSerializer.Serialize(comments);
        await File.WriteAllTextAsync(_filePath, commentsAsJson);
    }

    public async Task<List<Comment>> GetCommentsByUserIdAsync(int userId)
    {
        var commentsAsJson = await File.ReadAllTextAsync(_filePath);
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson) ?? new List<Comment>();
        List<Comment> commentsByUser = comments.Where(c => c.UserId == userId.ToString()).ToList();
        return commentsByUser;
    }
}
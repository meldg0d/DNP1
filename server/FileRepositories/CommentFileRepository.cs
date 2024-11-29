using System.Text.Json;
using Entities;
using RepositoryContracts;

namespace FileRepositories;

public class CommentFileRepository
{
    private readonly string _filePath = "comments.json";
    private Random rnd = new Random();

    public CommentFileRepository()
    {
        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
        }

        CreateData();
    }


    public async Task<Comment> AddAsync(Comment comment, int userId)
    {
        var comments = await OpenJSonFileAsync();

        var maxId = comments.Count > 0 ? comments.Max(c => c.Id) + 1 : 1;
        comment.Id = maxId;
        comment.UserID = userId;
        comments.Add(comment);

        await CloseJSonFileAsync(comments);
        return comment;
    }

    public async Task UpdateAsync(Comment comment)
    {
        var comments = await OpenJSonFileAsync();

        var existingComment = comments.SingleOrDefault(c => c.Id == comment.Id);
        if (existingComment == null)
        {
            throw new InvalidOperationException(
                $"Comment with ID '{comment.Id}' not found");
        }

        comments.Remove(existingComment);
        comments.Add(comment);

        await CloseJSonFileAsync(comments);
    }

    public async Task DeleteAsync(int id)
    {
        var comments = await OpenJSonFileAsync();

        var comment = comments.SingleOrDefault(c => c.Id == id);
        if (comment == null)
        {
            throw new InvalidOperationException("Comment with ID '" + id + "' not found");
        }

        comments.Remove(comment);

        await CloseJSonFileAsync(comments);
    }

    public async Task<Comment> GetSingleAsync(int id)
    {
        var comments = await OpenJSonFileAsync();
        var comment = comments.SingleOrDefault(c => c.Id == id);
        if (comment == null)
        {
            throw new InvalidOperationException("Comment with ID '" + id + "' not found");
        }

        await CloseJSonFileAsync(comments);
        return comment;
    }

    public IEnumerable<Comment> GetManyAsync()
    {
        var comments = OpenJSonFileAsync().Result;
        _ = CloseJSonFileAsync(comments);
        return comments.AsQueryable();
    }
    

    private async Task<List<Comment>> OpenJSonFileAsync()
    {
        var commentsAsJson = await File.ReadAllTextAsync(_filePath);
        var comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson)!;
        return comments;
    }

    private async Task CloseJSonFileAsync(List<Comment> comments)
    {
        var commentsAsJson = JsonSerializer.Serialize(comments);
        await File.WriteAllTextAsync(_filePath, commentsAsJson);
    }
    private async void CreateData()
    {

        var user = await OpenJSonFileAsync();
        if (user.Count == 0)
        {
            var comments = OpenJSonFileAsync();
            Comment comment1 = new Comment(1, "Hi!!!", 1, 1);
            Comment comment11 = new Comment(4, "Test", 1, 1);
            Comment comment111 = new Comment(5, "Test123", 1, 1);
            Comment comment2 = new Comment(2, "Hi!!!", 2, 2);
            Comment comment3 = new Comment(3, "Hi!!!", 3, 3);
            List<Comment> commentstoJson = new List<Comment>();
            commentstoJson.Add(comment1);
            commentstoJson.Add(comment11);
            commentstoJson.Add(comment111);
            commentstoJson.Add(comment2);
            commentstoJson.Add(comment3);
            await CloseJSonFileAsync(commentstoJson);
        }
    }
}
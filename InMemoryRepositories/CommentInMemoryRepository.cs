using GithubTest;

namespace InMemoryRepositories;

public class CommentInMemoryRepository : ICommentRepository
{
    
    private readonly List<Comment> _comments = new List<Comment>();
    
    
    public Task<List<Comment>> GetAllCommentsAsync()
    {
        return Task.FromResult(_comments);
    }

    public IQueryable<Comment> GetCommentsQuery()
    {
        return _comments.AsQueryable();
    }

    public Task<Comment> GetCommentByIdAsync(int id)
    {
       Comment? comment = _comments.FirstOrDefault(c => c.Id == id);
       if (comment is null)
       {
           throw new InvalidOperationException("No comment found");
       }
       return Task.FromResult(comment);
    }

    public Task<Comment> CreateCommentAsync(Comment comment)
    {
        comment.Id = _comments.Any() ? _comments.Max(c => c.Id) + 1 : 1;
        _comments.Add(comment);
        return Task.FromResult(comment);
    }

    public Task<Comment> UpdateCommentAsync(Comment comment)
    {
        Comment? existingComment = _comments.FirstOrDefault(c => c.Id == comment.Id);
        if (existingComment is null)
        {
            throw new InvalidOperationException("No comment found");
        }
        
        _comments.Remove(existingComment);
        _comments.Add(comment);
        
        return Task.FromResult(comment);
    }

    public Task DeleteCommentAsync(Comment comment)
    {
        Comment? existingComment = _comments.FirstOrDefault(c => c.Id == comment.Id);
        if (existingComment is null)
        {
            throw new InvalidOperationException("No comment found");
        }
        
        _comments.Remove(existingComment);
        return Task.CompletedTask;
    }

    public Task DeleteCommentByIdAsync(int id)
    {
        var existingComment = _comments.FirstOrDefault(c => c.Id == id);
        if (existingComment is null)
        {
            throw new InvalidOperationException("No comment found");
        }
        _comments.RemoveAll(c => c.Id == id); 
        return Task.CompletedTask;
    }

    public Task<List<Comment>> GetCommentsByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }
}
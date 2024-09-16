namespace GithubTest;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllCommentsAsync();
    
    IQueryable<Comment> GetCommentsQuery();
    
    Task<Comment> GetCommentByIdAsync(int id);
    Task<Comment> CreateCommentAsync(Comment comment);
    Task<Comment> UpdateCommentAsync(Comment comment);
    Task DeleteCommentAsync(Comment comment);
    Task DeleteCommentByIdAsync(int id);
    Task<List<Comment>> GetCommentsByUserIdAsync(int userId);
    
}
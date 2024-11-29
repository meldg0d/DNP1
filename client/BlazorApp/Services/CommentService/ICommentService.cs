using ApiContracts.DTOs.CommentDTOs;
using ApiContracts.DTOs.PostDTOs;

namespace BlazorApp.Services.CommentService;

public interface ICommentService
{
    Task<ResponseComment> AddAsync(ResponseComment comment, int userId);
    Task UpdateAsync(RequestComment comment);
    Task DeleteAsync(int id);
    Task<ResponseComment> GetSingleAsync(int id);
    Task<IEnumerable<ResponseComment>> GetManyAsync();
}
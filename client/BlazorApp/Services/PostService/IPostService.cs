using ApiContracts.DTOs.PostDTOs;

namespace BlazorApp.Services.PostService;

public interface IPostService
{
    Task<ResponsePost> AddAsync(RequestPost post);
    Task UpdateAsync(ResponsePost post);
    Task DeleteAsync(int id);
    Task<ResponsePost> GetSingleAsync(int id);
    Task<IEnumerable<ResponsePost>> GetManyAsync();
}
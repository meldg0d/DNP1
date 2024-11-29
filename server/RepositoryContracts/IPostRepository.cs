using System.Collections;
using Entities;

namespace RepositoryContracts;

public interface IPostRepository
{
    Task<Post> AddAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(int id);
    Task<Post> GetSingleAsync(int id);
    IEnumerable<Post> GetManyAsync();
    public Task<bool> CheckIfPostExistsAsync(int id);
}
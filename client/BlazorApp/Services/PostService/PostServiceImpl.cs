using ApiContracts.DTOs.PostDTOs;

namespace BlazorApp.Services.PostService;

public class PostServiceImpl(HttpClient _client) : IPostService
{
    public async Task<ResponsePost> AddAsync(RequestPost post)
    {
        HttpResponseMessage response = await _client.PostAsJsonAsync("/posts", post);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ResponsePost>();
    }

    public Task UpdateAsync(ResponsePost post)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponsePost> GetSingleAsync(int id)
    {
        HttpResponseMessage response = await _client.GetAsync($"/posts/{id}");
        
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<ResponsePost>();
    }

    public async Task<IEnumerable<ResponsePost>> GetManyAsync()
    {
        HttpResponseMessage response = await _client.GetAsync("/posts");
        
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<IEnumerable<ResponsePost>>();
    }
}
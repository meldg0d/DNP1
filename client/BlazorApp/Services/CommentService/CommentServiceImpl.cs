using ApiContracts.DTOs.CommentDTOs;

namespace BlazorApp.Services.CommentService;

public class CommentServiceImpl(HttpClient httpClient) : ICommentService
{
    public async Task<ResponseComment> AddAsync(ResponseComment comment, int userId)
    {
        HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("/comments", comment);

        responseMessage.EnsureSuccessStatusCode();

        return await responseMessage.Content.ReadFromJsonAsync<ResponseComment>();
    }

    public async Task UpdateAsync(RequestComment comment)
    {
        HttpResponseMessage response = await httpClient.PutAsJsonAsync("/comments", comment);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        HttpResponseMessage response = await httpClient.DeleteAsync($"/comments/{id}");
        
        response.EnsureSuccessStatusCode();
    }

    public async Task<ResponseComment> GetSingleAsync(int id)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"/comments/{id}");
        
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<ResponseComment>();
    }

    public async Task<IEnumerable<ResponseComment>> GetManyAsync()
    {
        var response = await httpClient.GetAsync("/comments");
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<IEnumerable<ResponseComment>>(); 
    }
}
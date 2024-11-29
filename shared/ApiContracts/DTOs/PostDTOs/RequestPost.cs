namespace ApiContracts.DTOs.PostDTOs;

public class RequestPost
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string Body { get; set; }
    public int UserId { get; set; }

    public RequestPost(int id, string title, string body, int userId)
    {
        Id = id;
        Title = title;
        Body = body;
        UserId = userId;
    }

    public RequestPost()
    {
    }
}
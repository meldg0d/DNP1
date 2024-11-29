namespace ApiContracts.DTOs.PostDTOs;

public class CreatePostDto
{
    public string Title { get; set; }
    public string Body { get; set; }
    public int UserId { get; set; }

    public CreatePostDto(int id, string title, string body, int userId)
    {
        Title = title;
        Body = body;
        UserId = userId;
    }
}
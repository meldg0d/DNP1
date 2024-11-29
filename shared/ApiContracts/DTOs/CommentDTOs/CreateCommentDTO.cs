namespace ApiContracts.DTOs.CommentDTOs;

public class CreateCommentDto
{
    public String Body { get; set; }
    public int PostID { get; set; }
    public int UserID { get; set; }

    public CreateCommentDto(string body, int postId, int userId)
    {
        Body = body;
        UserID = userId;
    }

    public CreateCommentDto()
    {
    }
}
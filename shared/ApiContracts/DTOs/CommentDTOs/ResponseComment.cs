namespace ApiContracts.DTOs.CommentDTOs;

public class ResponseComment
{
    public int Id { get; set; }
    public String Body { get; set; }
    public int PostID { get; set; }
    public int UserID { get; set; }

    public ResponseComment(int id, string body, int postId, int userId)
    {
        Id = id;
        Body = body;
        PostID = postId;
        UserID = userId;
    }

    public ResponseComment()
    {
    }
}
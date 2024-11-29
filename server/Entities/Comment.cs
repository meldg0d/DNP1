namespace Entities;

public class Comment
{
    public int Id { get; set; }
    public String Body { get; set; }
    public int UserID { get; set; }
    public int PostId { get; set; }
    
    
    public virtual User User { get; set; }
    public virtual Post Post { get; set; }
    
    
    public Comment()
    {
    }

    public Comment(int id, string body, int postId, int userId)
    {
        Id = id;
        Body = body;
        PostId = postId;
        UserID = userId;
    }
}
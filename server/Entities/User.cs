namespace Entities;

public class User
{
    public int Id { get; set; }
    public String Username { get; set; }
    public String Password { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Post> Posts { get; set; }

    public User()
    {
        Comments = new List<Comment>(); 
        Posts = new List<Post>();
    }

    public User(int id, string username, string password)
    {
        Id = id;
        Username = username;
        Password = password;
    }
}
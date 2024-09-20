namespace GithubTest;

public class User
{
    public User(string username, string password)
    {
        int id = new Random().Next();
        Username = username;
        Password = password;
    }

    public User(int id, string username, string password)
    {
        Id = id;
        Username = username;
        Password = password;
    }

    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
namespace ApiContracts.DTOs.UserDTOs;

public class UserRequest
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public UserRequest(int id, string username, string password)
    {
        Id = id;
        Username = username;
        Password = password;
    }

    public UserRequest()
    {
        
    }
}
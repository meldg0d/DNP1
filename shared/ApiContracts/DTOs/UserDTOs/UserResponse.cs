using Entities;

namespace ApiContracts.DTOs.UserDTOs;

public class UserResponse
{
    public int Id { get; set; }
    public string Username { get; set; }

    public UserResponse(int id, string username)
    {
        Id = id;
        Username = username;
    }

    public static UserResponse MapUserToResponse(User user)
    {
        return new UserResponse(user.Id, user.Username);
    }
}
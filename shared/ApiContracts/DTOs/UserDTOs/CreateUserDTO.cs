namespace ApiContracts.DTOs.UserDTOs;

public class CreateUserDTO
{
    public required String username { get; set; }

    public required String password { get; set; }

    public CreateUserDTO(string username, string password)
    {
        this.username = username;
        this.password = password;
    }
}
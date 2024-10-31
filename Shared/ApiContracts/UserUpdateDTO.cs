using System.ComponentModel.DataAnnotations;

namespace ApiContracts;

public class UserUpdateDTO
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
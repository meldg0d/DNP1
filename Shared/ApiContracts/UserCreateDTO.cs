using System.ComponentModel.DataAnnotations;

namespace ApiContracts;

public class UserCreateDTO
{
    [Required]
    [StringLength(20, ErrorMessage = "Username cannot exceed 20 characters.")]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    
}
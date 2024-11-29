using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("/auth")]
public class AuthController(IUserRepository _userRepository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> createUser(User user)
    {
        return Ok(await _userRepository.AuthLoginASync(user));
    }
    
    
    
}
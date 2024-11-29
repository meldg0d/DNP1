using ApiContracts.DTOs.UserDTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("users")]
public class UsersController(IUserRepository _userRepository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(UserRequest newUser)
    {
        
        ArgumentNullException.ThrowIfNull(newUser);

        newUser.Id = _userRepository.GetManyAsync().Count() + 1;
        
        var newUserCreate = new User(newUser.Id, newUser.Username, newUser.Password);

        await _userRepository.AddAsync(newUserCreate);

        return Ok(newUserCreate);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(User userToUpdate)
    {
        ArgumentNullException.ThrowIfNull(userToUpdate);

        await _userRepository.UpdateAsync(userToUpdate);
        return Ok("User updated");
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSingleUser(int id)
    {
        ArgumentNullException.ThrowIfNull(id);

        return Ok(await _userRepository.GetSingleAsync(id));
    }

    [HttpGet]
    public IQueryable<User> GetAllUsers()
    {
        return _userRepository.GetManyAsync();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser(int id)
    {
        ArgumentNullException.ThrowIfNull(id);
        
        await _userRepository.DeleteAsync(id);
        
        return Ok("User deleted");
    }
}
using GithubTest;
using Microsoft.AspNetCore.Mvc;
using ApiContracts;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new List<User>();
        private static int nextId = 1;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var userDtos = await Task.Run(() =>
                    users.Select(u => new UserReadDTO
                    {
                        Id = u.Id,
                        Username = u.Username
                    }).ToList()
                );

                return Ok(userDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await Task.Run(() => users.Find(u => u.Id == id));
                if (user == null)
                {
                    return NotFound();
                }

                var userDto = new UserReadDTO
                {
                    Id = user.Id,
                    Username = user.Username
                };

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateDTO userCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = new User
                {
                    Id = nextId++,
                    Username = userCreateDto.Username,
                    Password = HashPassword(userCreateDto.Password)
                };

                await Task.Run(() => users.Add(user));

                var userReadDto = new UserReadDTO
                {
                    Id = user.Id,
                    Username = user.Username
                };

                return CreatedAtAction(nameof(GetById), new { id = user.Id }, userReadDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserUpdateDTO userUpdateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingUser = await Task.Run(() => users.Find(u => u.Id == id));
                if (existingUser == null)
                {
                    return NotFound();
                }

                if (!string.IsNullOrEmpty(userUpdateDto.Username))
                {
                    existingUser.Username = userUpdateDto.Username;
                }

                if (!string.IsNullOrEmpty(userUpdateDto.Password))
                {
                    existingUser.Password = HashPassword(userUpdateDto.Password);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await Task.Run(() => users.Find(u => u.Id == id));
                if (user == null)
                {
                    return NotFound();
                }

                await Task.Run(() => users.Remove(user));

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private string HashPassword(string password)
        {
            // Implement a secure hashing algorithm
            return password;
        }
    }
}

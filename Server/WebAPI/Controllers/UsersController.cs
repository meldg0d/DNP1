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
        public IActionResult GetAll()
        {
            var userDtos = users.Select(u => new UserReadDTO
            {
                Id = u.Id,
                Username = u.Username
                // Do not include Password
            }).ToList();

            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var userDto = new UserReadDTO
            {
                Id = user.Id,
                Username = user.Username
                // Do not include Password
            };

            return Ok(userDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserCreateDTO userCreateDto)
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

            users.Add(user);

            var userReadDto = new UserReadDTO
            {
                Id = user.Id,
                Username = user.Username
            };

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, userReadDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserUpdateDTO userUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = users.Find(u => u.Id == id);
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            users.Remove(user);

            return NoContent();
        }
        
        
        private string HashPassword(string password)
        {
            // Implement a secure hashing algorithm
            return password;
        }
    }
}

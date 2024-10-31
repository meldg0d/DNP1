using GithubTest;           // Namespace where your Post entity is defined
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ApiContracts;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private static List<Post> posts = new List<Post>();
        private static int nextId = 1;  // To assign unique IDs to posts

        [HttpGet]
        public IActionResult GetAll()
        {
            var postDtos = posts.Select(p => new PostReadDTO
            {
                Id = p.Id,
                Title = p.Title,
                Body = p.Body
            }).ToList();

            return Ok(postDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var post = posts.Find(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            var postDto = new PostReadDTO
            {
                Id = post.Id,
                Title = post.Title,
                Body = post.Body
            };

            return Ok(postDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PostCreateDTO postCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = new Post
            {
                Id = nextId++,
                Title = postCreateDto.Title,
                Body = postCreateDto.Body
            };

            posts.Add(post);

            var postReadDto = new PostReadDTO
            {
                Id = post.Id,
                Title = post.Title,
                Body = post.Body
            };

            return CreatedAtAction(nameof(GetById), new { id = post.Id }, postReadDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PostUpdateDTO postUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingPost = posts.Find(p => p.Id == id);
            if (existingPost == null)
            {
                return NotFound();
            }

            existingPost.Title = postUpdateDto.Title;
            existingPost.Body = postUpdateDto.Body;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var post = posts.Find(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            posts.Remove(post);

            return NoContent();
        }
    }
}

using GithubTest;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("[api/posts]")]
public class PostsController : ControllerBase
{
    private static List<Post> posts = new List<Post>();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var post = posts.Find(p => p.Id == id);
        if (post == null)
        {
            return NotFound();
        }

        return Ok(post);
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] Post post)
    {
        posts.Add(post);
        return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Post post)
    {
        var existingPost = posts.Find(p => p.Id == id);
        if (existingPost == null)
        {
            return NotFound();
        }
        existingPost.Title = post.Title;
        existingPost.Body = post.Body;
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
    
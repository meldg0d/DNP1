using GithubTest;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/comments")]
public class CommentsController : ControllerBase
{
    private static List<Comment> comments = new List<Comment>();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(comments);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var comment = comments.Find(c => c.Id == id);
        if (comment == null)
        {
            return NotFound();
        }
        return Ok(comment);
    }

    
    [HttpPost]
    public IActionResult Create([FromBody] Comment comment)
    {
        comments.Add(comment);
        return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Comment comment)
    {
        var existingComment = comments.Find(c => c.Id == id);
        if (existingComment == null)
        {
            return NotFound();
        }
        existingComment.Content = comment.Content;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var comment = comments.Find(c => c.Id == id);
        if (comment == null)
        {
            return NotFound();
        }
        comments.Remove(comment);
        return NoContent();
    }
}


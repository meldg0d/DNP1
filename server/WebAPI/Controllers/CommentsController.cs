using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("comments")]
public class CommentsController(ICommentRepository _commentRepository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateComment(Comment comment)
    {   
        ArgumentNullException.ThrowIfNull(comment);
        return Ok(await _commentRepository.AddAsync(comment));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateComment(Comment comment)
    {
        ArgumentNullException.ThrowIfNull(comment);
        await _commentRepository.UpdateAsync(comment);
        return Ok("Comment updated");
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSingleComment(int id)
    {
        var comment = await _commentRepository.GetSingleAsync(id);
        ArgumentNullException.ThrowIfNull(comment);

        return Ok(comment);
    }

    [HttpGet]
    public IEnumerable<Comment> GetAllComments()
    {
        return _commentRepository.GetManyAsync();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSingleComment(int id)
    {
        await _commentRepository.DeleteAsync(id);
        return Ok("Comment deleted");
    }
}
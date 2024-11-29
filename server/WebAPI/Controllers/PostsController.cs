using ApiContracts.DTOs.PostDTOs;
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("posts")]
public class PostsController(IPostRepository _postRepository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePost(RequestPost newPost)
    {
        ArgumentNullException.ThrowIfNull(newPost);

        newPost.Id = _postRepository.GetManyAsync().Count() + 1;
        
        Post newPostEntity = new Post(newPost.Id, newPost.Title, newPost.Body, 1);

        await _postRepository.AddAsync(newPostEntity);

        return Ok(newPost);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePost(Post postToUpdate)
    {
        ArgumentNullException.ThrowIfNull(postToUpdate);

        await _postRepository.UpdateAsync(postToUpdate);

        return Ok();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSinglePost(int id)
    {
        var post = await _postRepository.GetSingleAsync(id);

        ArgumentNullException.ThrowIfNull(post);

        return Ok(post);
    }

    [HttpGet]
    public IEnumerable<Post> GetAllPosts()
    {
        var posts = _postRepository.GetManyAsync();
        
        ArgumentNullException.ThrowIfNull(posts);

        return posts;
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePost(int id)
    {
        await _postRepository.DeleteAsync(id);

        return Ok();
    }
}
using System.Net.NetworkInformation;
using ApiContracts.DTOs.CommentDTOs;
using EfcRepositories.EfcSetup;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RepositoryContracts;

namespace EfcRepositories.EfcRepositories;

public class CommentRepository(AppContext1 ctx) : ICommentRepository
{
    public async Task<Comment> AddAsync(Comment comment)
    {
        EntityEntry<Comment> entityEntry = await ctx.Comments.AddAsync(comment);
        await ctx.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task UpdateAsync(Comment comment)
    {
        if (!(await ctx.Comments.AnyAsync(p => p.Id == comment.Id)))
        {
            throw new KeyNotFoundException("Post with id {post.Id} not found");
        }

        ctx.Comments.Update(comment);
        await ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Comment? existing = await ctx.Comments.SingleOrDefaultAsync(c => c.Id == id);
        if (existing == null)
        {
            throw new KeyNotFoundException($"Post with id {id} not found");
        }

        ctx.Comments.Remove(existing);
        await ctx.SaveChangesAsync();
    }

    public async Task<Comment> GetSingleAsync(int id)
    {
        Comment? comment = await ctx.Comments.SingleOrDefaultAsync(c => c.Id == id);

        if (comment == null)
        {
            throw new KeyNotFoundException($"Post with id {id} not found");
        }

        return comment;
    }

    public IEnumerable<Comment> GetManyAsync()
    {
        return ctx.Comments.AsQueryable();
    }

    public Task<IQueryable<Comment>> FindCommentsForPostAsync(int id)
    {
        throw new NotImplementedException();
    }
}
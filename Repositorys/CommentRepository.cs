using FinSharkk.Data;
using FinSharkk.DTOs.Comment;
using FinSharkk.Interfaces;
using FinSharkk.Models;
using Microsoft.EntityFrameworkCore;

namespace FinSharkk.Repositorys;

public class CommentRepository : ICommentRepository
{
    private readonly AppDbContext _context;

    public CommentRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Comment>> GetAllAsync()
    {
        var comments = await _context.Comments.ToListAsync();
        return comments;
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await _context.Comments.FirstOrDefaultAsync(x=>x.Id == id);
    }

    public async Task<Comment?> AddAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment?> UpdateAsync(int id, UpdateCommentRequestDto commentDto)
    {
       var comment = await _context.Comments.FindAsync(id);
       if (comment == null) return null;
       comment.Title = commentDto.Title;
       comment.Content = commentDto.Content;
       await _context.SaveChangesAsync();
       return comment;
    }

    public async Task<Comment?> DeleteAsync(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null) return null;
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return comment;
    }
}
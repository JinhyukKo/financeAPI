using FinSharkk.Data;
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
    
}
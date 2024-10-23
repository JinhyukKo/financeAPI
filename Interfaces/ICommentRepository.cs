using FinSharkk.DTOs.Comment;
using FinSharkk.Models;

namespace FinSharkk.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllAsync();
    Task<Comment?> GetByIdAsync(int id);
    Task<Comment> AddAsync(Comment comment);
    Task<Comment?> UpdateAsync(int id , UpdateCommentRequestDto comment);
    Task<Comment?> DeleteAsync(int id);
    
}
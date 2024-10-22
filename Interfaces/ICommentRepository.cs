using FinSharkk.Models;

namespace FinSharkk.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllAsync();
}
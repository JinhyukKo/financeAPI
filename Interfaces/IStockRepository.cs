using FinSharkk.DTOs.Stock;
using FinSharkk.Models;

namespace FinSharkk.Interfaces;

public interface IStockRepository
{   
    public Task<List<Stock>> GetAllAsync(); 
    public Task<Stock?> GetByIdAsync(int id);
    public Task<Stock> AddAsync(Stock stock);
    public Task<Stock?> UpdateAsync(int id ,UpdateStockRequestDto updateDto);
    public Task<Stock?> DeleteAsync(int id);
    public Task<bool> ExistsAsync(int id);
}
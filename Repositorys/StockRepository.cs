using FinSharkk.Data;
using FinSharkk.DTOs.Stock;
using FinSharkk.Interfaces;
using FinSharkk.Models;
using Microsoft.EntityFrameworkCore;

namespace FinSharkk.Repositorys;

public class StockRepository : IStockRepository
{
    private readonly AppDbContext _context;
    public StockRepository (AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Stock>> GetAllAsync()
    {
        var stocks =await _context.Stocks.Include(x => x.Comments).ToListAsync();
        return stocks;
    }
 
    public async Task<Stock?> GetByIdAsync(int id)
    {
        var stock = await (from s in _context.Stocks
            where s.Id == id
            select s)
            .FirstOrDefaultAsync();
        return stock;
    }

    public async Task<Stock> AddAsync(Stock stock)
    {
        await _context.Stocks.AddAsync(stock);
        await _context.SaveChangesAsync();
        return stock;
    }

    public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateDto)
    {
        var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        if (stock == null) return null;
        stock.Symbol = updateDto.Symbol;
        stock.CompanyName = updateDto.CompanyName;
        stock.MarketCap = updateDto.MarketCap;
        stock.Purchase = updateDto.Purchase;
        stock.Industry = updateDto.Industry;
        await _context.SaveChangesAsync();
        
        return stock;
        
    }

    public async Task<Stock?> DeleteAsync(int id)
    {
        var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        if (stock == null) return null;
        _context.Stocks.Remove(stock);
        await _context.SaveChangesAsync();
        return stock;
    }
    public async Task<bool> ExistsAsync(int id)
    {
       return await _context.Stocks.AnyAsync(x => x.Id == id);
    }
}
using FinSharkk.DTOs.Stock;
using FinSharkk.Models;

namespace FinSharkk.Mappers;

public static class StockMapper
{
    public static StockDto ToDto(this Stock stock)
    {
        return new StockDto()
        {
            Id = stock.Id,
            Symbol = stock.Symbol,
            CompanyName = stock.CompanyName,
            Industry = stock.Industry,
            LastDiv =  stock.LastDiv,
            Purchase = stock.Purchase,
            MarketCap = stock.MarketCap,
            Comments =stock.Comments.Select(c => c.ToDto()).ToList(),
        };
    }

    public static Stock CreateDtoToStock(this CreateStockRequestDto stockDto)
    {
        return new Stock()
        {
            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            Industry = stockDto.Industry,
            LastDiv =  stockDto.LastDiv,
            Purchase = stockDto.Purchase, 
            MarketCap = stockDto.MarketCap,
        };
    }
}
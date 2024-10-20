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
        };
    }

    public static Stock ToStock(this StockDto stockDto)
    {
        return new Stock()
        {
            Id = stockDto.Id,
            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            Industry = stockDto.Industry,
            LastDiv =  stockDto.LastDiv,
            Purchase = stockDto.Purchase, 
        };
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinSharkk.Data;
using FinSharkk.DTOs.Stock;
using FinSharkk.Mappers;
using FinSharkk.Models;

namespace FinSharkk.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StockController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // var stocks = _context.Stocks.ToList();
            var stocksDTO = (from stock in _context.Stocks select stock)
                .ToList()
                .Select(x=> x.ToDto()) ;
            return Ok(stocksDTO);

        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            // var stock = _context.Stocks.Find(id);
            // var stock = _context.Stocks.Where(stock => stock.Id == id).FirstOrDefault();
            var stock = (from s in _context.Stocks
                where s.Id == id
                select s).FirstOrDefault();
            if (stock == null) return NotFound();
            var stockDto = stock.ToDto();
            return Ok(stockDto);

        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockRequestDto)
        {
            Stock stock = stockRequestDto.CreateDtoToStock();
            _context.Stocks.Add(stock);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock.ToDto());
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var stock = _context.Stocks.FirstOrDefault(x => x.Id == id);
            if(stock == null) return NotFound();
            stock.Symbol = updateDto.Symbol;
            stock.CompanyName = updateDto.CompanyName;
            stock.MarketCap = updateDto.MarketCap;
            stock.Purchase = updateDto.Purchase;
            stock.Industry = updateDto.Industry;
            stock.LastDiv = updateDto.LastDiv;
            
            // _context.Stocks.Update(stock);
            _context.SaveChanges();
            return Ok(stock.ToDto());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var stock = _context.Stocks.FirstOrDefault(x => x.Id == id);
            if (stock == null) return NotFound();
            _context.Stocks.Remove(stock);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

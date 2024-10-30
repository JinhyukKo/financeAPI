using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinSharkk.Data;
using FinSharkk.DTOs.Stock;
using FinSharkk.Helpers;
using FinSharkk.Interfaces;
using FinSharkk.Mappers;
using FinSharkk.Models;

namespace FinSharkk.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IStockRepository _stockRepo;

        public StockController(AppDbContext context, IStockRepository stockRepo)
        {
            _context = context;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] StockQuery query)
        {
            List<Stock> stocks = await _stockRepo.GetAllAsync(query);
            var stocksDto = (from stock in stocks select stock)
                .Select(x => x.ToDto()).ToList();
            return Ok(stocksDto);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            // var stock = _context.Stocks.Find(id);
            // var stock = _context.Stocks.Where(stock => stock.Id == id).FirstOrDefault();
            // var stock = (from s in _context.Stocks
            //     where s.Id == id
            //     select s).FirstOrDefault();
            var stock = await _stockRepo.GetByIdAsync(id);
            if (stock == null) return NotFound();
            return Ok(stock.ToDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockRequestDto)
        {
            Stock stock = stockRequestDto.CreateDtoToStock();
            await _stockRepo.AddAsync(stock);
            return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock.ToDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            Stock? stock = await _stockRepo.UpdateAsync(id, updateDto);
            if(stock == null) return NotFound();
            return Ok(stock.ToDto());  
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete([FromRoute] int id)
        {
            Stock? stock = await _stockRepo.DeleteAsync(id);
            if (stock == null) return NotFound();
            return NoContent();
        }
    }
}

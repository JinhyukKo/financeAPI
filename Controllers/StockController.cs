using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinSharkk.Data;
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
            var query = from stock in _context.Stocks select stock;
            return Ok(query.ToList());

        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            // var stock = _context.Stocks.Find(id);
            // var stock = _context.Stocks.Where(stock => stock.Id == id).FirstOrDefault();
            // if(stock==null) return NotFound();
            var query = from stock in _context.Stocks 
                where stock.Id == id
                select stock;
            return Ok(query.FirstOrDefault());

        } 
    }
}

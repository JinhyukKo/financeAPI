using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinSharkk.Data;
using FinSharkk.DTOs.Comment;
using FinSharkk.Interfaces;
using FinSharkk.Mappers;
using FinSharkk.Models;
using FinSharkk.Repositorys;

namespace FinSharkk.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;

        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }

        // GET: api/Comment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetComments()
        {
            var comments = await _commentRepo.GetAllAsync();
            var commentsDto = comments.Select(x=>x.ToDto());
            return Ok(commentsDto);
        }

        //GET: api/Comment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> GetComment(int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);
        
            if (comment == null)
            {
                return NotFound();
            }
            return comment.ToDto();
        }
        //
        // To protect from overposting attacks, see https://go.microsoft. com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, UpdateCommentRequestDto commentReqDto)
        {
            var comment =  await _commentRepo.UpdateAsync(id,commentReqDto);
            if(comment == null) return NotFound();
            return Ok(comment.ToDto());
        }
        //
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{stockId}")]
        public async Task<ActionResult<Comment>> PostComment([FromRoute]int stockId , [FromBody]CreateCommentRequestDto commentDto)
        {
            if (!await _stockRepo.ExistsAsync(stockId)) return NotFound();
            var comment =await _commentRepo.AddAsync(commentDto.CreateDtoToEntity(stockId));
            
            return CreatedAtAction(nameof(GetComment), new {id = comment.Id}, comment.ToDto());
        }
        //
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _commentRepo.DeleteAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        //
        // private bool CommentExists(int id)
        // {
        //     return _context.Comments.Any(e => e.Id == id);
        // }
    }
}

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
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;

        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        // GET: api/Comment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            var comments = await _commentRepo.GetAllAsync();
            var commentsDto = comments.Select(x=>x.ToDto());
            return Ok(commentsDto);
        }

        // GET: api/Comment/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Comment>> GetComment(int id)
        // {
        //     var comment = await _context.Comments.FindAsync(id);
        //
        //     if (comment == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return comment;
        // }
        //
        // // PUT: api/Comment/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutComment(int id, Comment comment)
        // {
        //     if (id != comment.Id)
        //     {
        //         return BadRequest();
        //     }
        //
        //     _context.Entry(comment).State = EntityState.Modified;
        //
        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!CommentExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }
        //
        //     return NoContent();
        // }
        //
        // // POST: api/Comment
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Comment>> PostComment(Comment comment)
        // {
        //     _context.Comments.Add(comment);
        //     await _context.SaveChangesAsync();
        //
        //     return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
        // }
        //
        // // DELETE: api/Comment/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteComment(int id)
        // {
        //     var comment = await _context.Comments.FindAsync(id);
        //     if (comment == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     _context.Comments.Remove(comment);
        //     await _context.SaveChangesAsync();
        //
        //     return NoContent();
        // }
        //
        // private bool CommentExists(int id)
        // {
        //     return _context.Comments.Any(e => e.Id == id);
        // }
    }
}

using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollarController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public CollarController(ApiDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Collar>> Get()
            => await _context.Collars.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(Collar), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _context.Collars.FindAsync(id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Collar collar)
        {
            await _context.Collars.AddAsync(collar);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = collar.collar_id });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Collar collar)
        {
            if (id != collar.collar_id) return BadRequest();

            _context.Entry(collar).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var issueToDelete = await _context.Collars.FindAsync(id);

            if (issueToDelete == null) return NotFound();

            _context.Collars.Remove(issueToDelete);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

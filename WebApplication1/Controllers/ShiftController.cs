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
    public class ShiftController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public ShiftController(ApiDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Shift>> Get()
            => await _context.Shifts.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(Shift), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _context.Shifts.FindAsync(id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Shift shift)
        {
            await _context.Shifts.AddAsync(shift);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = shift.shift_id });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Shift shift)
        {
            if (id != shift.shift_id) return BadRequest();

            _context.Entry(shift).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var issueToDelete = await _context.Shifts.FindAsync(id);

            if (issueToDelete == null) return NotFound();

            _context.Shifts.Remove(issueToDelete);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

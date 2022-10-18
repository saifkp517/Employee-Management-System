using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly Data.ApiDbContext _context;
        public LoginController(Data.ApiDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Login>> Get()
            => await _context.LoggedIn.ToListAsync();

        [HttpGet("email")]
        [ProducesResponseType(typeof(Registration), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string email)
        {
            var issue = await _context.LoggedIn.Where(x => x.Email == email).ToListAsync();
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Login login)
        {
            await _context.LoggedIn.AddAsync(login);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = login.Id });
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete()
        {
            var issueToDelete = _context.LoggedIn.Take(2);

            if (issueToDelete == null) return NotFound();

            _context.LoggedIn.RemoveRange(issueToDelete);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

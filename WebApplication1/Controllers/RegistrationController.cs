using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System.Web.Http.Cors;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(origins: "https://localhost:3000", headers: "*", methods: "*")]
    public class RegistrationController : ControllerBase
    {

        private readonly Data.ApiDbContext _context;
        public RegistrationController(Data.ApiDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Registration>> Get()
            => await _context.Registers.ToListAsync();

        [HttpGet("email")]
        [ProducesResponseType(typeof(Registration), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string email)
        {
            var issue = await _context.Registers.Where(x => x.Email == email).ToListAsync();
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Registration register)
        {
            await _context.Registers.AddAsync(register);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = register.Id});  
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Registration register)
        {
            if (id != register.Id) return BadRequest();

            _context.Entry(register).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var issueToDelete = await _context.Registers.FindAsync(id);

            if(issueToDelete == null) return NotFound();

            _context.Registers.Remove(issueToDelete);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

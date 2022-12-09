using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSqlite.Data;
using WebApiSqlite.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperActionController : ControllerBase
    {
        private readonly WebApiSqliteContext _context;
        public DeveloperActionController(WebApiSqliteContext context)
        {
            _context = context;
        }
        // GET: api/<DeveloperActionController>
        [HttpGet]
        public IEnumerable<Developer> GetDevelopersWithActions()
        {
            return _context.Developers.Include(a => a.ActionItems).ToList();
        }

        // GET api/<DeveloperActionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Developer>> GetDeveloperActions(int id)
        {
            Developer? developer = await _context.Developers
                .Include(a => a.ActionItems)
                .FirstOrDefaultAsync(d => d.DeveloperId == id);

            if (developer == null)
            {
                return NotFound();
            }

            return Ok(developer);
        }

        // POST api/<DeveloperActionController>
        [HttpPost]
        public async Task<ActionResult<Developer>> PostAsync([FromBody] Developer developer)
        {
            _context.Developers.Add(developer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDeveloperActions), new { id = developer.DeveloperId }, developer);
        }

        // POST api/<DeveloperActionController>/AddAction
        [HttpPost("/api/DeveloperAction/AddActionItem")]
        public async Task<ActionResult<Developer>> PostActionItem([FromBody] ActionItem actionItem)
        {
            _context.ActionItems.Add(actionItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDeveloperActions), new { id = actionItem.DeveloperId }, actionItem);
        }

        // PUT api/<DeveloperActionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Developer>> Put(int id, [FromBody] ActionItem actionItem)
        {
            Developer? developer = await _context.Developers
                .Include(a => a.ActionItems)
                .FirstOrDefaultAsync(d => d.DeveloperId == id);

            if (developer == null)
            {
                return NotFound();
            }

            developer.ActionItems.Add(actionItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDeveloperActions), new { id = developer.DeveloperId }, developer);

        }

        // DELETE api/<DeveloperActionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Developer? developer = await _context.Developers
                .Include(a => a.ActionItems)
                .FirstOrDefaultAsync(d => d.DeveloperId == id);

            if (developer == null)
            {
                return NotFound();
            }

            _context.Remove(developer);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
